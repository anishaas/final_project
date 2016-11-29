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
                                       albumSongs = album.AlbumSongs
                                   };

            albumDetailsQuery = albumDetailsQuery.Where(album => album.albumId == id);

            if (albumDetailsQuery == null)
            {
                return HttpNotFound();
            }

            var albumDetailsList = albumDetailsQuery.ToList();

            /*
            ViewBag.songPrice = songDetailsList[2];
            ViewBag.artistName = songDetailsList[3];
            ViewBag.songRating = "N/A";
            */
            ViewBag.albumDetailJSON = JsonConvert.SerializeObject(albumDetailsList);
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
            return View("~/Views/SandBoxViews/Details/artistDetails.cshtml");
        }

    }
}