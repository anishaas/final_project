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

namespace FinalProject.Controllers.SandBoxControllers
{
    public class SandBoxController : Controller
    {
        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

        // GET: SandBox
        public ActionResult Index()
        {
            return View("~/Views/SandBoxViews/userViewLayout.cshtml");
        }
        public ActionResult getCustomerWelcomePage()
        {

            return View("~/Views/SandBoxViews/WelcomePage/customerWelcomePage.cshtml");
        }

        //SEARCH RELATED
        public ActionResult getCustomerSongSearchPage()
        {
            return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");
        }

        public ActionResult getCustomerAlbumSearchPage()
        {
            return View("~/Views/SandBoxViews/Search/AlbumSearch/customerAlbumSearch.cshtml");
        }

        public ActionResult getCustomerArtistSearchPage()
        {
            return View("~/Views/SandBoxViews/Search/ArtistSearch/artistSearch.cshtml");
        }

        public ActionResult getMyMusicPage()
        {
            return View("~/Views/SandBoxViews/AccountScreens/MyMusic.cshtml");
        }


        //DETAILS RELATED

        public ActionResult getSongDetailsPage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var songDetailsQuery = from song in db.Songs
                             select new
                             {
                                 SongID = song.SongID,
                                 SongTitle = song.SongTitle,
                                 SongPrice = song.SongPrice,
                                 ArtistName = song.SongArtist.ArtistName,
                                 Featured = song.Featured,
                                 SongGenres = song.SongGenres,
                                 SongAlbums = song.SongAlbums
                             };

            songDetailsQuery = songDetailsQuery.Where(s => s.SongID == id);

            if (songDetailsQuery == null)
            {
                return HttpNotFound();
            }

            var songDetailsList = songDetailsQuery.ToList();

            ViewBag.songDetailJSON = JsonConvert.SerializeObject(songDetailsList);

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

            return View("~/Views/SandBoxViews/Details/songDetails.cshtml");
        }


        public ActionResult getUserAccountPage()
        {
            return View("~/Views/SandBoxViews/AccountScreens/ManageAccount.cshtml");
        }
        public ActionResult getNewAccountPage()
        {
            return View("~/Views/SandBoxViews/AccountScreens/NewAccount.cshtml");
        }
        public ActionResult getLoginPage()
        {
            return View("~/Views/SandBoxViews/AccountScreens/Login.cshtml");
        }
    }
}