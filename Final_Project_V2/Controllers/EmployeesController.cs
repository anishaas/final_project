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

        // GET: SongReviews
        //check this method for multiple roles
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult ManageSongReviews()
        {
            var query = from r in db.UserActivityInputs
                        select r;

            List < UserActivityInput > allUserActivity = query.ToList();
            List <UserActivityInput> customerReviews = db.UserActivityInputs.Where(x => x.UserActivityInputType == 3).ToList();
            return View(customerReviews);
        }

        // GET: AlbumReviews
        //check this method for multiple roles
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult ManageAlbumReviews()
        {
            var query = from r in db.UserActivityInputs
                        select r;

            List<UserActivityInput> allUserActivity = query.ToList();
            List<UserActivityInput> albumReviews = db.UserActivityInputs.Where(x => x.UserActivityInputType == 5).ToList();
            return View(albumReviews);
        }

        // GET: ArtistReviews
        //check this method for multiple roles
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult ManageArtistReviews()
        {
            var query = from r in db.UserActivityInputs
                        select r;

            List<UserActivityInput> allUserActivity = query.ToList();
            List<UserActivityInput> artistReviews = db.UserActivityInputs.Where(x => x.UserActivityInputType == 7).ToList();
            return View(artistReviews);
        }

        [Authorize(Roles = "Employee, Admin")]
        // GET: Admins/EditSongReview/5
        public ActionResult EditSongReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //find passed in review
            UserActivityInput @songReview = db.UserActivityInputs.Find(id);
            return View("~/Views/Employees/EditSongReview.cshtml", @songReview);
        }
        [Authorize(Roles = "Employee, Admin")]
        // POST: Admins/EditSongReview/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSongReview([Bind(Include = "UserActivityInputID,UserActivityInputTxt1")] UserActivityInput @songReview)
        {
            if (ModelState.IsValid)
            {
                //Find associated review
                UserActivityInput songReviewToChange = db.UserActivityInputs.Find(@songReview.UserActivityInputID);
                songReviewToChange.UserActivityInputTxt1 = @songReview.UserActivityInputTxt1;

                db.Entry(songReviewToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageSongReviews", "Employees");
            }
            return View("~/Views/Employees/EditSongReview.cshtml", @songReview);
        }

        [Authorize(Roles = "Employee, Admin")]
        // GET: Admins/EditAlbumReview/5
        public ActionResult EditAlbumReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //find passed in review
            UserActivityInput @albumReview = db.UserActivityInputs.Find(id);
            return View("~/Views/Employees/EditAlbumReview.cshtml", @albumReview);
        }
        [Authorize(Roles = "Employee, Admin")]
        // POST: Admins/EditAlbumReview/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAlbumReview([Bind(Include = "UserActivityInputID,UserActivityInputTxt1")] UserActivityInput @albumReview)
        {
            if (ModelState.IsValid)
            {
                //Find associated review
                UserActivityInput albumReviewToChange = db.UserActivityInputs.Find(@albumReview.UserActivityInputID);
                albumReviewToChange.UserActivityInputTxt1 = @albumReview.UserActivityInputTxt1;

                db.Entry(albumReviewToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageAlbumReviews", "Employees");
            }
            return View("~/Views/Employees/EditAlbumReview.cshtml", @albumReview);
        }

        [Authorize(Roles = "Employee, Admin")]
        // GET: Admins/EditArtistReview/5
        public ActionResult EditArtistReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //find passed in review
            UserActivityInput @artistReview = db.UserActivityInputs.Find(id);
            return View("~/Views/Employees/EditArtistReview.cshtml", @artistReview);
        }
        [Authorize(Roles = "Employee, Admin")]
        // POST: Admins/EditArtistReview/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArtistReview([Bind(Include = "UserActivityInputID,UserActivityInputTxt1")] UserActivityInput @artistReview)
        {
            if (ModelState.IsValid)
            {
                //Find associated review
                UserActivityInput artistReviewToChange = db.UserActivityInputs.Find(@artistReview.UserActivityInputID);
                artistReviewToChange.UserActivityInputTxt1 = @artistReview.UserActivityInputTxt1;

                db.Entry(artistReviewToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageArtistReviews", "Employees");
            }
            return View("~/Views/Employees/EditArtistReview.cshtml", @artistReview);
        }

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
                //Find associated employee
                AppUser employeeToChange = db.Users.Find(User.Identity.GetUserId());
                employeeToChange.Address = @employee.Address;
                employeeToChange.Phone = @employee.Phone;
                employeeToChange.Password = @employee.Password;

                db.Entry(employeeToChange).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Employees");
        }

        public ActionResult Details()
        {
            AppUser employeeToView = db.Users.Find(User.Identity.GetUserId());
            if (employeeToView == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(employeeToView);
        }


        //GET: Employees/ManageCustomers
        [Authorize(Roles = "Employee, Admin")]
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
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult EditCustomer(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser @customer = db.Users.Find(id);
            return View("~/Views/Employees/EditCustomer.cshtml", @customer);
        }

        [Authorize(Roles = "Employee, Admin")]
        // POST: Employees/EditCustomer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "Id,Phone,DisabledCustomer,Password,FirstName,LastName,Email,CCNumber1,CCNumber2")] AppUser @customer)
        {
            if (ModelState.IsValid)
            {
                //Find associated customer
                AppUser customerToChange = db.Users.Find(@customer.Id);

                customerToChange.FirstName = @customer.FirstName;
                customerToChange.LastName = @customer.LastName;
                customerToChange.Email = @customer.Email;
                customerToChange.Phone = @customer.Phone;
                customerToChange.Password = @customer.Password;
                customerToChange.DisabledCustomer = @customer.DisabledCustomer;
                customerToChange.CCNumber1 = @customer.CCNumber1;
                customerToChange.CCNumber2 = @customer.CCNumber2;
                //assign credit card type
                //AmericanExpress
                if (customerToChange.CCNumber1 == null)
                {
                    customerToChange.CCType1 = " ";
                }
                else if (customerToChange.CCNumber1 != null && customerToChange.CCNumber1.Length == 15)
                {
                    customerToChange.CCType1 = "AmericanExpress";
                    //All other cards
                }
                else if (customerToChange.CCNumber1 != null && customerToChange.CCNumber1.Length == 16)
                {
                    if (customerToChange.CCNumber1.Substring(0, 2) == "54")
                    {
                        customerToChange.CCType1 = "MasterCard";
                    }
                    else if (customerToChange.CCNumber1.Substring(0, 1) == "4")
                    {
                        customerToChange.CCType1 = "Visa";
                    }
                    else if (customerToChange.CCNumber1.Substring(0, 1) == "6")
                    {
                        customerToChange.CCType1 = "Discover";
                    }
                    else
                    {
                        //error message to ViewBag
                        ViewBag.ErrorMessage = "That is not a valid credit card number. Please enter a valid credit card number";
                    }
                }

                    if (customerToChange.CCNumber2 == null)
                    {
                        customerToChange.CCType2 = " ";
                    }
                    else if (customerToChange.CCNumber2 != null && customerToChange.CCNumber2.Length == 15)
                    {
                        customerToChange.CCType2 = "AmericanExpress";
                        //All other cards
                    }
                    else if (customerToChange.CCNumber2 != null && customerToChange.CCNumber2.Length == 16)
                    {
                        if (customerToChange.CCNumber2.Substring(0, 2) == "54")
                        {
                            customerToChange.CCType2 = "MasterCard";
                        }
                        else if (customerToChange.CCNumber2.Substring(0, 1) == "4")
                        {
                            customerToChange.CCType2 = "Visa";
                        }
                        else if (customerToChange.CCNumber2.Substring(0, 1) == "6")
                        {
                            customerToChange.CCType2 = "Discover";
                        }
                        else
                        {
                            //error message to ViewBag
                            ViewBag.ErrorMessage = "That is not a valid credit card number. Please enter a valid credit card number";
                        }
                    }
                db.Entry(customerToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageCustomers", "Employees");
            }
               return View("~/Views/Employees/EditCustomer.cshtml", @customer);
            }
        }
    }