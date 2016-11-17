using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers.SandBoxControllers
{
    public class SandBoxController : Controller
    {
        // GET: SandBox
        public ActionResult Index()
        {
            return View("~/Views/SandBoxViews/userViewLayout.cshtml");
        }

        public ActionResult getCustomerSongSearchPage()
        {
            return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");
        }

        public ActionResult getCustomerAlbumSearchPage()
        {
            return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");
        }

        public ActionResult getSongDetailsPage()
        {
            return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");
        }
        public ActionResult getAlbumDetailsPage()
        {
            return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");
        }
        public ActionResult getUserAccountPage()
        {
            return View("~/Views/SandBoxViews/AccountScreens/ManageAccount.cshtml");
        }
        public ActionResult getLoginPage()
        {
            return View("~/Views/SandBoxViews/AccountScreens/Login.cshtml");
        }
    }
}