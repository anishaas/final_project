using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Final_Project_V2.Controllers
{
    public class EmployeesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employees
        [Authorize(Roles = "Employee")]
        public ActionResult Index()
        {
            if (!User.IsInRole("Employee"))
            {
                return RedirectToAction("Login", "Account");
            }

            var query = from c in db.Users
                        select c;
            List<AppUser> allEmployees = query.ToList();
            String EmployeeGUID = db.AppRoles.FirstOrDefault(r => r.Name == "Employee").Id;
            allEmployees = db.Users.Where(x => x.Roles.Any(s => s.RoleId == EmployeeGUID)).ToList();
            return View(allEmployees);
        }

        // GET: Employees/Edit
        [Authorize(Roles = "Employee")]
        public ActionResult Edit()
        {
            //if the logged in user is an employee, they edit their own account
            string id = User.Identity.GetUserId();
            AppUser @employee = db.Users.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(@employee);
        }

        // POST: Employees/Edit
        [Authorize(Roles = "Employee")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Address,Phone,Password")] AppUser @employee)
        {
            if (ModelState.IsValid)
            {
                //Find associated member
                AppUser employeeToChange = db.Users.Find(@employee.Id);

                db.Entry(employeeToChange).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        //GET: Employees/ManageCustomers
        [Authorize(Roles = "Employee")]
        public ActionResult ManageCustomers()
        {

            var query = from c in db.Users
                        select c;
            List<AppUser> allCustomers = query.ToList();

            String CustomerGUID = db.AppRoles.FirstOrDefault(r => r.Name == "Customer").Id;
            allCustomers = db.Users.Where(x => x.Roles.Any(s => s.RoleId == CustomerGUID)).ToList();
            return View(allCustomers);
        }

        // GET: Employees/EditCustomer/5
        [Authorize(Roles = "Employee")]
        public ActionResult EditCustomer(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser @customer = db.Users.Find(id);
            return View("~/Views/Employees/EditCustomer.cshtml", @customer);
        }

        [Authorize(Roles = "Employee")]
        // POST: Employees/EditCustomer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "UserID,LastName,FirstName,EmailAddress,Phone,CCType1,CCNumber1,CCType2,CCNumber2")] AppUser @customer)
        {
            if (ModelState.IsValid)
            {
                //Find associated customer
                AppUser customerToChange = db.Users.Find(@customer.Id);

                //update customer properties based on edits
                customerToChange.LastName = @customer.LastName;
                customerToChange.FirstName = @customer.FirstName;
                customerToChange.Email = @customer.Email;
                customerToChange.Phone = @customer.Phone;

                //assign credit card type
                //AmericanExpress
                if (@customer.CCNumber1.Length == 15)
                {
                    @customer.CCType1 = "AmericanExpress";
                    //All other cards
                }
                else if (@customer.CCNumber1.Length == 16)
                {
                    if (@customer.CCNumber1.Substring(0, 2) == "54")
                    {
                        @customer.CCType1 = "MasterCard";
                    }
                    else if (@customer.CCNumber1.Substring(0, 1) == "4")
                    {
                        @customer.CCType1 = "Visa";
                    }
                    else if (@customer.CCNumber1.Substring(0, 1) == "6")
                    {
                        @customer.CCType1 = "Discover";
                    }
                    else
                    {
                        //error message to ViewBag
                        ViewBag.ErrorMessage = "That is not a valid credit card number. Please enter a valid credit card number";
                    }

                }
                //update exisitng credit cards
                customerToChange.CCType1 = @customer.CCType1;
                customerToChange.CCNumber1 = @customer.CCNumber1;
                customerToChange.CCType2 = @customer.CCType2;
                customerToChange.CCNumber2 = @customer.CCNumber2;


                db.Entry(customerToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Employees/EditCustomer.cshtml",@customer);
        }
    }
}