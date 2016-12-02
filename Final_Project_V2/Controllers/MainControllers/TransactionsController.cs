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
        
        public ActionResult getOrderHistory()
        {
            return View("~/Views/SandBoxViews/Transactions/orderHistory.cshtml");
        }

        public ActionResult getMyMusicPage()
        {
            return View("~/Views/SandBoxViews/Transactions/myMusic.cshtml");
        }
        public ActionResult getCheckOutPage()
        {
            //PROVIDING USER DATA TO THE VIEWBAG
            var userLastName = "";
            var userFirstName = "";
            var userID = User.Identity.GetUserId();
            var authenticationStatus = "none";
            var cc1 = "";
            var cc1Type = "";
            var cc2 = "";
            var cc2Type = "";

            if (User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<AppUser>(new AppDbContext());
                var manager = new UserManager<AppUser>(userStore);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                userLastName = currentUser.LastName;
                userFirstName = currentUser.FirstName;
                authenticationStatus = currentUser.EmpType;
                cc1 = currentUser.CCNumber1;
                cc1Type = currentUser.CCType1;
                cc2 = currentUser.CCNumber2;
                cc2Type = currentUser.CCType2;
            }

            ViewBag.authenticationStatus = authenticationStatus;
            ViewBag.userLastName = userLastName;
            ViewBag.userFirstName = userFirstName;
            ViewBag.userID = userID;
            ViewBag.CCNumber1 = cc1;
            ViewBag.CCType1 = cc1Type;
            ViewBag.CCNumber2 = cc2;
            ViewBag.CCType2 = cc2Type;

            return View("~/Views/SandBoxViews/Transactions/checkout.cshtml");
        }
        public ActionResult getShoppingCart()
        {

            //PROVIDING USER DATA TO THE VIEWBAG
            var userLastName = "";
            var userFirstName = "";
            var userID = User.Identity.GetUserId();
            var userEmail = "";
            var authenticationStatus = "none";
            var cc1 = "";
            var cc1Type = "";
            var cc2 = "";
            var cc2Type = "";

            if (User.Identity.IsAuthenticated)
            {

                var userStore = new UserStore<AppUser>(new AppDbContext());
                var manager = new UserManager<AppUser>(userStore);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                userLastName = currentUser.LastName;
                userFirstName = currentUser.FirstName;
                userEmail = currentUser.Email;
                authenticationStatus = currentUser.EmpType;
                cc1 = currentUser.CCNumber1;
                cc1Type = currentUser.CCType1;
                cc2 = currentUser.CCNumber2;
                cc2Type = currentUser.CCType2;
            }

            ViewBag.authenticationStatus = authenticationStatus;
            ViewBag.userLastName = userLastName;
            ViewBag.userFirstName = userFirstName;
            ViewBag.userID = userID;
            ViewBag.CCNumber1 = cc1;
            ViewBag.CCType1 = cc1Type;
            ViewBag.CCNumber2 = cc2;
            ViewBag.CCType2 = cc2Type;
            ViewBag.userEmail = userEmail;

            return View("~/Views/SandBoxViews/Transactions/shoppingCart.cshtml");
        }


    }
}