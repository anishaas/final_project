using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project_V2.Controllers.MainControllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getAlbumDetailsPage()
        {
            return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");
        }

    }
}