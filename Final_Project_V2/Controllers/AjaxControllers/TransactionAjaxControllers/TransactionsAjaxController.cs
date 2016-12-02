using Final_Project_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public string getAlbumReviews()
        {
            var albumID = Request.Form["albumID"];

            var albumReviewQuery = from input in db.UserActivityInputs
                                  select input;

            albumReviewQuery = albumReviewQuery.Where(input => input.UserActivityInputType == 5 && input.UserActivityInputArg1 == albumID);

            if (albumReviewQuery == null)
            {
                return "No history found";
            }

            var albumReviewList = albumReviewQuery.ToList();

            return JsonConvert.SerializeObject(albumReviewList);
        }
        public string getSongReviews()
        {

            var songID = Request.Form["songID"];

            var songReviewQuery = from input in db.UserActivityInputs
                                        select input;

            songReviewQuery = songReviewQuery.Where(input => input.UserActivityInputType == 3 && input.UserActivityInputArg1 == songID);

            if (songReviewQuery == null)
            {
                return "No history found";
            }

            var songReviewList = songReviewQuery.ToList();

            return JsonConvert.SerializeObject(songReviewList);
        }
        public string checkAccountStatus()
        {
            var userIDz = "";
            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

                var userStore = new UserStore<AppUser>(new AppDbContext());
                var manager = new UserManager<AppUser>(userStore);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                var customerStatus = currentUser.DisabledCustomer;
                if (customerStatus == true)
                {
                    return "invalid";
                }else
                {
                    return "valid";
                }
            }
            return "invalid";

            
        }
        public string getAllArtists()
        {
            var artistsQuery = from artist in db.Artists
                              select artist;
            var artistList = artistsQuery.ToList();

            return JsonConvert.SerializeObject(artistList);
        }
        public string getAllGenres()
        {
            var genresQuery = from genre in db.Genres
                              select genre;
            var genresList = genresQuery.ToList();

            return JsonConvert.SerializeObject(genresList);
        }
        public string getAllAlbums()
        {
            var albumsQuery = from album in db.Albums
                             select album;
            var albumsList = albumsQuery.ToList();

            return JsonConvert.SerializeObject(albumsList);
        }
        public string getAllSongs()
        {
            var songsQuery = from song in db.Songs
                             select song;
            var songsList = songsQuery.ToList();

            return JsonConvert.SerializeObject(songsList);
        }
        public string getOrderData()
        {
            var userIDz = "";
            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }

            var userOrderHistoryQuery = from input in db.UserActivityInputs
                                        select input;

            userOrderHistoryQuery = userOrderHistoryQuery.Where(input => input.UserActivityInputType == 9);

            if (userOrderHistoryQuery == null)
            {
                return "No history found";
            }

            var userOrderHistoryList = userOrderHistoryQuery.ToList();

            return JsonConvert.SerializeObject(userOrderHistoryList);
        }
        public string cancelOrder()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            var orderID = Request.Form["orderID"];

            //Delete the relevant order
            db.UserActivityInputs.RemoveRange(
                db.UserActivityInputs.Where(u => u.UserActivityInputType == 9 && u.UserActivityInputArg2 == userIDz && u.UserActivityInputArg1 == orderID)
                );
            try
            {
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }

           

        }

        public string submitArtistReview()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            else
            {
                return "user not authenticated";
            }

            var numRating = Request.Form["numRating"];
            var textReview = Request.Form["textReview"];
            var artistID = Request.Form["artistID"];

            UserActivityInput userInputRating = new UserActivityInput
            {
                UserActivityInputType = 8,
                UserActivityInputArg1 = artistID,
                UserActivityInputArg2 = userIDz,
                UserActivityInputTxt1 = numRating
            };

            UserActivityInput userInputReview = new UserActivityInput
            {
                UserActivityInputType = 7,
                UserActivityInputArg1 = artistID,
                UserActivityInputArg2 = userIDz,
                UserActivityInputTxt1 = textReview
            };

            if (!db.UserActivityInputs.Any(u => u.UserActivityInputArg1 == artistID && u.UserActivityInputArg2 == userIDz))
            {
                db.UserActivityInputs.Add(userInputRating);
                db.UserActivityInputs.Add(userInputReview);
            }
            else
            {
                UserActivityInput c = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == artistID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 7
                                       select x).First();
                c.UserActivityInputTxt1 = textReview;

                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == artistID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 8
                                       select x).First();
                b.UserActivityInputTxt1 = numRating;
            }

            try
            {
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }


        }

        public string getArtistNumRating()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            else
            {
                return "user not authenticated";
            }

            var artistID = Request.Form["artistID"];


            try
            {
                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == artistID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 8
                                       select x).First();
                var numRating = b.UserActivityInputTxt1;

                return numRating;
            }
            catch (Exception e)
            {
                return "noRating";
            }
        }

        public string getArtistReview()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();
            }
            else
            {
                return "user not authenticated";
            }
            var artistID = Request.Form["artistID"];
            try
            {
                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == artistID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 7
                                       select x).First();
                var textreview = b.UserActivityInputTxt1;
                return textreview;
            }
            catch (Exception e)
            {
                return "noReview";
            }
        }

        public string getAlbumNumRating()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            else
            {
                return "user not authenticated";
            }

            var albumID = Request.Form["albumID"];


            try
            {
                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == albumID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 6
                                       select x).First();
                var numRating = b.UserActivityInputTxt1;

                return numRating;
            }
            catch (Exception e)
            {
                return "noRating";
            }
        }


        public string getAlbumReview()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();
            }
            else
            {
                return "user not authenticated";
            }
            var albumID = Request.Form["albumID"];
            try
            {
                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == albumID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 5
                                       select x).First();
                var textreview = b.UserActivityInputTxt1;
                return textreview;
            }
            catch (Exception e)
            {
                return "noReview";
            }
        }

        public string getSongNumRating()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            else
            {
                return "user not authenticated";
            }

            var songID = Request.Form["songID"];

            try
            {
                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == songID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 4
                                       select x).First();
                var numRating = b.UserActivityInputTxt1;

                return numRating;
            }
            catch (Exception e)
            {
                return "NoRating";
            }

        }

        public string getSongReview()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();
            }
            else
            {
                return "user not authenticated";
            }   
            var songID = Request.Form["songID"];
            try
            {
                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == songID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 3
                                       select x).First();
                var textreview = b.UserActivityInputTxt1;

                return textreview;
            }
            catch (Exception e)
            {
                return "No Rating";
            }

        }
        public string submitAlbumReview()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            else
            {
                return "user not authenticated";
            }

            var numRating = Request.Form["numRating"];
            var textReview = Request.Form["textReview"];
            var albumID = Request.Form["albumID"];

            UserActivityInput userInputRating = new UserActivityInput
            {
                UserActivityInputType = 6,
                UserActivityInputArg1 = albumID,
                UserActivityInputArg2 = userIDz,
                UserActivityInputTxt1 = numRating
            };

            UserActivityInput userInputReview = new UserActivityInput
            {
                UserActivityInputType = 5,
                UserActivityInputArg1 = albumID,
                UserActivityInputArg2 = userIDz,
                UserActivityInputTxt1 = textReview
            };

            if (!db.UserActivityInputs.Any(u => u.UserActivityInputArg1 == albumID && u.UserActivityInputArg2 == userIDz))
            {
                db.UserActivityInputs.Add(userInputRating);
                db.UserActivityInputs.Add(userInputReview);
            }
            else
            {
                UserActivityInput c = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == albumID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 5
                                       select x).First();
                c.UserActivityInputTxt1 = textReview;

                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == albumID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 6
                                       select x).First();
                b.UserActivityInputTxt1 = numRating;
            }

            try
            {
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }


        }
        public string submitReview()
        {
            var userIDz = "";

            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();

            }
            else
            {
                return "user not authenticated";
            }

            var numRating = Request.Form["numRating"];
            var textReview = Request.Form["textReview"];
            var songID = Request.Form["songID"];

            UserActivityInput userInputRating = new UserActivityInput
            {
                UserActivityInputType = 4,
                UserActivityInputArg1 = songID,
                UserActivityInputArg2 = userIDz,
                UserActivityInputTxt1 = numRating
            };

            UserActivityInput userInputReview = new UserActivityInput
            {
                UserActivityInputType = 3,
                UserActivityInputArg1 = songID,
                UserActivityInputArg2 = userIDz,
                UserActivityInputTxt1 = textReview
            };

            if (!db.UserActivityInputs.Any(u => u.UserActivityInputArg1 == songID && u.UserActivityInputArg2 == userIDz))
            {
                db.UserActivityInputs.Add(userInputRating);
                db.UserActivityInputs.Add(userInputReview);
            }else
            {
                UserActivityInput c = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == songID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 3
                                       select x).First();
                c.UserActivityInputTxt1 = textReview;

                UserActivityInput b = (from x in db.UserActivityInputs
                                       where x.UserActivityInputArg1 == songID && x.UserActivityInputArg2 == userIDz && x.UserActivityInputType == 4
                                       select x).First();
                b.UserActivityInputTxt1 = numRating;
            }

            try
            {
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "fail";
            }
 
           
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
            var songList = Request.Form["songList"];
            var albumList = Request.Form["albumList"];
            var recipientEmail = Request.Form["recipientEmail"];
            var giftStatus = Request.Form["gift"];
            var userIDz = "";
            var userEmail = "";
            if (User.Identity.IsAuthenticated)
            {
                userIDz = User.Identity.GetUserId();
                var userStore = new UserStore<AppUser>(new AppDbContext());
                var manager = new UserManager<AppUser>(userStore);
                var currentUser = manager.FindById(User.Identity.GetUserId());

                userEmail = currentUser.Email;
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

                if (giftStatus == "true")
                {
                    SendEmail(userEmail, "Gift Sent", "Your gift to " + recipientEmail + " was sent." +" If need be here is a refund link to refund the order:<a href='http://localhost:50346/transactions/refundOrder/" + newOrderNum + "'>Refund Link</a>");

                    SendEmail(recipientEmail, "Gift from " + userEmail, "You got a gift of the following songs: (" + songList + ")" + "and albums:(" + albumList + ")");

                }
                else
                {
                    //TODO Switch out local host for our azure host!
                    SendEmail(recipientEmail, "Your purchase", "You bought the following songs: (" + songList + ")" + "and albums:(" + albumList + ")." + " If need be here is a refund link to refund the order:<a href='http://localhost:50346/transactions/refundOrder/" + newOrderNum  + "'>Refund Link</a>");
                }


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

            return JsonConvert.SerializeObject(songDetailsList, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

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
                                       albumSongs = album.AlbumSongs,
                                       albumGenres = album.AlbumGenres
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

        public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)
        {                   
            //Create an email client to send the emails
            /*
            var client = new SmtpClient("smtp.gmail.com", 587)
            { Credentials = new NetworkCredential("throwawaymis333k@gmail.com", "peterfeng"), EnableSsl = true };

            client.UseDefaultCredentials = false;
            */

            var gmailClient = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("throwawaymis333k@gmail.com", "peterfeng")
            };


            //Add anything that you need to the body of the message      
            // /n is a new line – this will add some white space after the main body of the message            
            String finalMessage = emailBody + "\n\n This is a disclaimer that will be on all    messages. ";
            //Create an email address object for the sender address      
            MailAddress senderEmail = new MailAddress("throwawaymis333k@gmail.com", "Music Company");
            MailMessage mm = new MailMessage();
            mm.Subject = emailSubject;
            mm.Sender = senderEmail;
            mm.From = senderEmail;
            mm.To.Add (new MailAddress(toEmailAddress));
            mm.Body = finalMessage;
            gmailClient.Send(mm);
        }
        }


}