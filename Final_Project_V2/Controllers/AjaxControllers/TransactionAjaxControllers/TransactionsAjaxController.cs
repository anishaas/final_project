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
    public class TransactionsAjaxController : Controller
    {
        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

        // GET: Details
        public ActionResult Index()
        {
            return View();
        }

        public string getOrderHistory()
        {
            var userIDz = "";
            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }

            var userOrderHistoryQuery = from input in db.UserActivityInputs
                                        select input;

            userOrderHistoryQuery = userOrderHistoryQuery.Where(input => input.UserActivityInputArg2 == userIDz && input.UserActivityInputType == 9);

            if (userOrderHistoryQuery == null)
            {
                return "No history found";
            }

            var userOrderHistoryList = userOrderHistoryQuery.ToList();

            return JsonConvert.SerializeObject(userOrderHistoryList);
        }
        public string logOrder()
        {
            var orderJSON = Request.Form["orderJSON"];
            var recipientEmail = Request.Form["recipientEmail"];
            var userIDz = "";
            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            var orderLogs = db.UserActivityInputs.Where(u => u.UserActivityInputType == 9 && u.UserActivityInputArg2 == userIDz);
            var orderLogsList = orderLogs.ToList();

            List<int> orderNums = new List<int>();

            foreach (var item in orderLogsList)
            {
                int intOrderNum = Int32.Parse(item.UserActivityInputArg1);

                orderNums.Add(intOrderNum);
            }



            var maxOrderNum = 0;
            var newOrderNum = 0;
            if (orderNums.Count() == 0)
            {
                 newOrderNum = maxOrderNum + 1;
            }
            else
            {
                 maxOrderNum = orderNums.Max();
                 newOrderNum = maxOrderNum + 1;
            }


            // Create a new Order object.
            UserActivityInput userInput = new UserActivityInput
            {
                UserActivityInputType = 9,
                UserActivityInputArg1 = newOrderNum.ToString(),
                UserActivityInputArg2 = User.Identity.GetUserId(),
                UserActivityInputArg3 = orderJSON
            };

            db.UserActivityInputs.Add(userInput);

            // Submit the change to the database.
            try
            {
                
                var userID = "";
                //Write code to delete shopping cart afterwards
                if (User.Identity.IsAuthenticated)
                {
                    userID = User.Identity.GetUserId();
                }

                //Delete songs from shopping cart since they've now been purchased
                db.UserActivityInputs.RemoveRange(
                    db.UserActivityInputs.Where(u => u.UserActivityInputType == 1 && u.UserActivityInputArg2 == userID)
                    );

                //Delete albums from shopping cart since they've now been purchased
                db.UserActivityInputs.RemoveRange(
                        db.UserActivityInputs.Where(u => u.UserActivityInputType == 2 && u.UserActivityInputArg2 == userID)
                        );


                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {

                return e.ToString();

            }

            
        }
        public string checkIfUserExists()
        {
            var userID = Request.Form["userID"];
            var emailAddress = Request.Form["emailAddress"];
            if (db.Users.Any(u => u.Email == emailAddress))
            {
                return "true";
            }else
            {
                return "fail";
            }
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

            if (!db.UserActivityInputs.Any(u => u.UserActivityInputType == 1 && u.UserActivityInputArg1 == songID && u.UserActivityInputArg2 == userID && u.UserActivityInputArg3 == "no"))
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

            // Create a new Order object.
            UserActivityInput userInput = new UserActivityInput
            {
                UserActivityInputType = 2,
                UserActivityInputArg1 = albumID,
                UserActivityInputArg2 = userID,
                UserActivityInputArg3 = "no"
            };

            if (!db.UserActivityInputs.Any(u => u.UserActivityInputType == 2 && u.UserActivityInputArg1 == albumID && u.UserActivityInputArg2 == userID && u.UserActivityInputArg3 == "no"))
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
            }
            else
            {
                return "exists";
            }

        }

        public string getUserShoppingCartSongs()
        {
            var userID = Request.Form["userID"];
            var shoppingCartSongs = db.UserActivityInputs.Where(u => u.UserActivityInputType == 1 && u.UserActivityInputArg2 == userID && u.UserActivityInputArg3 == "no");

            return JsonConvert.SerializeObject(shoppingCartSongs);
        }

        public string getUserShoppingCartAlbums()
        {
            var userID = Request.Form["userID"];
            var shoppingCartAlbums = db.UserActivityInputs.Where(u => u.UserActivityInputType == 2 && u.UserActivityInputArg2 == userID && u.UserActivityInputArg3 == "no");

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
                                       ArtistName = song.SongArtist,
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

        public string deleteSong()
        {
            var songID = Request.Form["songID"];

            var cartSongToDelete = (from u in db.UserActivityInputs
                        where u.UserActivityInputArg1 == songID
                                    select u).FirstOrDefault();

            //Delete it from memory
            db.UserActivityInputs.Remove(cartSongToDelete);

            //Save to database
            try
            {
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "fail";
            }
        }

        public string getAlbumDetails()
        {
            var albumID = Request.Form["albumID"];
            var albumIDInt = Int32.Parse(albumID);

            var albumDetailsQuery = from album in db.Albums
                                   select new
                                   {
                                       albumID = album.AlbumID,
                                       albumName = album.AlbumName,
                                       albumPrice = album.AlbumPrice,
                                       albumArtist = album.AlbumArtist.ArtistName,
                                       albumSongs = album.AlbumSongs
                                   };

            albumDetailsQuery = albumDetailsQuery.Where(a => a.albumID == albumIDInt);

            if (albumDetailsQuery == null)
            {
                return "Details not found";
            }

            var albumDetailsList = albumDetailsQuery.ToList();

            return JsonConvert.SerializeObject(albumDetailsList);
        }

        public string deleteAlbum()
        {
            var albumID = Request.Form["albumID"];

            var cartAlbumToDelete = (from u in db.UserActivityInputs
                                    where u.UserActivityInputArg1 == albumID
                                    select u).FirstOrDefault();

            //Delete it from memory
            db.UserActivityInputs.Remove(cartAlbumToDelete);
            //Save to database
            try
            {
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "fail";
            }
        }


    }


}