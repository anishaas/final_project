using Final_Project_V2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Final_Project_V2.Controllers.MainControllers
{
    public class TransactionsAjaxController : Controller
    {
        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

        // GET: Details
        public ActionResult Index()
        {
            return View();
        }


        public string addSongToCart()
        {
            var userID = Request.Form["userID"];
            var songID = Request.Form["songID"];

            // Create a new Order object.
            UserActivityInput userInput = new UserActivityInput
            {
                UserActivityInputType = 1,
                UserActivityInputArg1 = songID,
                UserActivityInputArg2 = userID,
                UserActivityInputArg3 = "no"
            };

            if (!db.UserActivityInputs.Any(u => u.UserActivityInputArg1 == songID && u.UserActivityInputArg2 == userID && u.UserActivityInputArg3 == "no"))
            {
                db.UserActivityInputs.Add(userInput);
                //db.SaveChanges();


                // Submit the change to the database.
                try
                {
                    db.SaveChanges();
                    return "success";
                }
                catch (Exception e)
                {
                    
                    return e.ToString();
                }
            }else
            {
                return "exists";
            }

        }

        public string addAlbumToCart()
        {
            var userID = Request.Form["userID"];
            var albumID = Request.Form["albumID"];


            return "success";
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
            return View("~/Views/SandBoxViews/Details/artistDetails.cshtml");
        }

    }
}