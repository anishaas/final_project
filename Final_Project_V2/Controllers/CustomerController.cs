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

        //[Authorize]
        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            AppUser customer = db.Users.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (customer.Id != User.Identity.GetUserId() && !User.IsInRole("Admins"))
            {
                return RedirectToAction("Login", "Account");
            }

            AppUser customers = db.Users.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View("~/ Views/SandBoxViews/WelcomePage/customerWelcomePage.cshtml");
        }


        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,LastName,FirstName,EmailAddress,Phone,CCType1,CCNumber1,CCType2,CCNumber2")] AppUser customers)
        {
            if (ModelState.IsValid)
            {
                //Find associated member
                AppUser customerToChange = db.Users.Find(customers.Id);

                db.Entry(customerToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("~/ Views/SandBoxViews/WelcomePage/customerWelcomePage.cshtml");
        }
    }
}