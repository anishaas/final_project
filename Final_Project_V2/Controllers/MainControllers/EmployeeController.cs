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


namespace Final_Project_V2.Controllers.MainControllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        // GET: Employees/Edit/5
        public ActionResult EditEmployee(string id)
        {
            AppUser employee = db.Users.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (employee.Id != User.Identity.GetUserId() && !User.IsInRole("Admins"))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        /*
        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,LastName,FirstName,emailAddress,phoneNumber,OKToText,Major")] AppUser members, int[] SelectedEvents)
        {
            if (ModelState.IsValid)
            {
                //Find associated member
                AppUser memberToChange = db.Users.Find(members.Id);


                //change events
                //remove any existing events
                memberToChange.Events.Clear();


                //if there are members to add, add them
                if (SelectedEvents != null)
                {
                    foreach (int EventID in SelectedEvents)
                    {
                        Event eventToAdd = db.Events.Find(EventID);
                        memberToChange.Events.Add(eventToAdd);
                    }
                }


                db.Entry(memberToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(members);
        }
        */
    }
}