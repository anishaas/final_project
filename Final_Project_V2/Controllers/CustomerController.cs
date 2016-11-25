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


namespace Final_Project_V2.Controllers
{
    public class CustomerController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Events/Edit/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser @customer = db.Users.Find(id);
            if (@customer == null)
            {
                return HttpNotFound();
            }
            /*
            //Might need these for some property?
            ViewBag.AllCardTypes = GetAllCommittees(@event);
            ViewBag.AllMembers = GetAllMembers(@event);
            */
            return View(@customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,LastName,FirstName,EmailAddress,Phone,CCType1,CCNumber1,CCType2,CCNumber2")] AppUser @customer)
        {
            if (ModelState.IsValid)
            {
                //Find associated member
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
                } else if (@customer.CCNumber1.Length == 16)
                {
                    if (@customer.CCNumber1.Substring(0, 2) == "54")
                    {
                        @customer.CCType1 = "MasterCard";
                    } else if (@customer.CCNumber1.Substring(0,1) == "4")
                    {
                        @customer.CCType1 = "Visa";
                    } else if (@customer.CCNumber1.Substring(0, 1) == "6")
                    {
                        @customer.CCType1 = "Discover";
                    } else {
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
            return View(@customer);
        }
    }
}