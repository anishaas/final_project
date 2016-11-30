using Final_Project_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Final_Project_V2.Controllers.MainControllers
{
    public class TransactionsController : Controller
    {
        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

        // GET: Details
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult getShoppingCart()
        {

            //PROVIDING USER DATA TO THE VIEWBAG
            var userLastName = "";
            var userFirstName = "";
            var userID = User.Identity.GetUserId();
            var authenticationStatus = "none";

            if (User.Identity.IsAuthenticated)
            {

                var userStore = new UserStore<AppUser>(new AppDbContext());
                var manager = new UserManager<AppUser>(userStore);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                userLastName = currentUser.LastName;
                userFirstName = currentUser.FirstName;
                authenticationStatus = currentUser.EmpType;

            }
            ViewBag.authenticationStatus = authenticationStatus;
            ViewBag.userLastName = userLastName;
            ViewBag.userFirstName = userFirstName;
            ViewBag.userID = userID;

            return View("~/Views/SandBoxViews/Transactions/shoppingCart.cshtml");
        }


    }
}