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

        public string getUserShoppingCartSongs()
        {
            var userID = Request.Form["userID"];
            var shoppingCartSongs = db.UserActivityInputs.Where(u => u.UserActivityInputType == 1 && u.UserActivityInputArg2 == userID);

            return JsonConvert.SerializeObject(shoppingCartSongs);
        }

        public string getUserShoppingCartAlbums()
        {
            var userID = Request.Form["userID"];
            var shoppingCartAlbums = db.UserActivityInputs.Where(u => u.UserActivityInputType == 2 && u.UserActivityInputArg2 == userID);

            return JsonConvert.SerializeObject(shoppingCartAlbums);
        }

        public string getSongDetails()
        {
            var songID = Request.Form["songID"];
            var songIDInt = Int32.Parse(songID);
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

            songDetailsQuery = songDetailsQuery.Where(s => s.SongID == songIDInt);

            if (songDetailsQuery == null)
            {
                return "Details not found";
            }

            var songDetailsList = songDetailsQuery.ToList();

            return JsonConvert.SerializeObject(songDetailsList);
        }

      

    }
}