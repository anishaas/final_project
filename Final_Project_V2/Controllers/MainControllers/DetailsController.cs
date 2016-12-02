using Final_Project_V2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Final_Project_V2.Controllers.MainControllers
{
    public class DetailsController : Controller
    {
        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

        // GET: Details
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult getAlbumDetailsPage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var albumDetailsQuery = from album in db.Albums
                                   select new
                                   {
                                       albumId = album.AlbumID,
                                       albumName = album.AlbumName,
                                       albumPrice = album.AlbumPrice,
                                       albumArtist = album.AlbumArtist.ArtistName,
                                       albumGenres = album.AlbumGenres,
                                       albumSongs = album.AlbumSongs,
                                       AlbumDiscountEnabled = album.AlbumDiscountEnabled,
                                       AlbumDiscount = album.AlbumDiscount
                                   };

            albumDetailsQuery = albumDetailsQuery.Where(album => album.albumId == id);

            if (albumDetailsQuery == null)
            {
                return HttpNotFound();
            }

            var albumDetailsList = albumDetailsQuery.ToList();

            ViewBag.albumDetailJSON = JsonConvert.SerializeObject(albumDetailsList);


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

                if (User.IsInRole("Admin"))
                {
                    ViewBag.userRole = "admin";
                }else if (User.IsInRole("Employee"))
                {
                    ViewBag.userRole = "employee";
                }
                else
                {
                    ViewBag.userRole = "customer";
                }
            }

            ViewBag.authenticationStatus = authenticationStatus;
            ViewBag.userLastName = userLastName;
            ViewBag.userFirstName = userFirstName;
            ViewBag.userID = userID;

            return View("~/Views/SandBoxViews/Details/AlbumDetails.cshtml");
        }

        public ActionResult getArtistDetailsPage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artistDetailsQuery = from artist in db.Artists
                                    select new
                                    {
                                        artistId = artist.ArtistID,
                                        artistName = artist.ArtistName,
                                        artistGenres = artist.ArtistGenres,
                                        artistSongs = artist.ArtistSongs,
                                        artistAlbums = artist.ArtistAlbums
                                    };

            artistDetailsQuery = artistDetailsQuery.Where(artist => artist.artistId == id);

            if (artistDetailsQuery == null)
            {
                return HttpNotFound();
            }

            var albumDetailsList = artistDetailsQuery.ToList();

            /*
            ViewBag.songPrice = songDetailsList[2];
            ViewBag.artistName = songDetailsList[3];
            ViewBag.songRating = "N/A";
            */
            ViewBag.artistDetailJSON = JsonConvert.SerializeObject(albumDetailsList);

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

            return View("~/Views/SandBoxViews/Details/artistDetails.cshtml");
        }

    }
}