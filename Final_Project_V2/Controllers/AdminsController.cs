using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Final_Project_V2.Controllers
{
    public class AdminsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admins/CreateSong
        public ActionResult CreateSong()
        {
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllArtists = GetAllArtists();
            return View();
        }

        // POST: Admins/CreateSong
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongID,SongTitle,SongPrice,Featured")] Song @song, int[] SelectedGenres, int[] SelectedArtists)
        {
 
            if (ModelState.IsValid)
            {
                //add genres
                if (SelectedGenres != null)
                {
                    
                    foreach (int Id in SelectedGenres)
                    {

                        Genre genreToAdd = db.Genres.Find(Id);
                        @song.SongGenres.Add(genreToAdd);
                    }
                }
                //add artists
                if (SelectedArtists != null)
                {
                    foreach (int Id in SelectedArtists)
                    {
                        Artist artistToAdd = db.Artists.Find(Id);
                        @song.SongArtists.Add(artistToAdd);
                    }
                }
                //save song to database
                db.Songs.Add(@song);
                db.SaveChanges();
                return RedirectToAction("ManageSongs");
            }


            return View();

        }


        // GET: Admins/CreateAlbum
        public ActionResult CreateAlbum()
        {
            return View();
        }

        // POST: Admins/CreateAlbum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAlbum([Bind(Include = "AlbumID,AlbumName,AlbumPrice,Featured")] Album @album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("ManageAlbums");
            }


            return View(album);
        }

        // GET: Admins/CreateArtist
        public ActionResult CreateArtist()
        {
            return View();
        }

        // POST: Admins/CreateArtist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "ArtistID,ArtistName,Featured")] Artist @artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("ManageArtists");
            }

            return View(artist);
        }

        //GET: Admins/ManageSongs
        [Authorize(Roles = "Admin")]
        public ActionResult ManageSongs()
        {

            var query = from s in db.Songs
                        select s;
            List<Song> allSongs = query.ToList();
            return View(allSongs);
        }

        // GET: Admins/EditSong/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditSong(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song @song = db.Songs.Find(id);
            return View("~/Views/Admins/EditSong.cshtml", @song);
        }

        [Authorize(Roles = "Admin")]
        // POST: Admins/EditSong/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSong([Bind(Include = "SongID,SongTitle,SongPrice,Featured,SongArtists")] Song @song)
        //LastName,FirstName,EmailAddress,CCType1,CCNumber1,CCType2,CCNumber2
        {
            if (ModelState.IsValid)
            {
                //Find associated customer
                Song songToChange = db.Songs.Find(@song.SongID);

                songToChange.SongTitle = @song.SongTitle;
                songToChange.SongPrice = @song.SongPrice;
                songToChange.SongArtists = @song.SongArtists;
                songToChange.Featured = @song.Featured;

                db.Entry(songToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageSongs", "Admins");
            }
            return View("~/Views/Admins/EditSong.cshtml", @song);
        }

        //GET: Admins/ManageAlbums
        [Authorize(Roles = "Admin")]
        public ActionResult ManageAlbums()
        {

            var query = from a in db.Albums
                        select a;
            List<Album> allAlbums = query.ToList();
            return View(allAlbums);
        }

        // GET: Admins/EditAlbum/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditAlbum(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album @album = db.Albums.Find(id);
            return View("~/Views/Admins/EditAlbum.cshtml", @album);
        }

        [Authorize(Roles = "Admin")]
        // POST: Admins/EditAlbum/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAlbum([Bind(Include = "AlbumID,AlbumName,AlbumPrice,Featured,AlbumArtist")] Album @album)
        //LastName,FirstName,EmailAddress,CCType1,CCNumber1,CCType2,CCNumber2
        {
            if (ModelState.IsValid)
            {
                //Find associated customer
                Album albumToChange = db.Albums.Find(@album.AlbumID);

                albumToChange.AlbumName = @album.AlbumName;
                albumToChange.AlbumPrice = @album.AlbumPrice;


                db.Entry(albumToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageSongs", "Admins");
            }
            return View("~/Views/Admins/EditAlbum.cshtml", @album);
        }

        //GET: Admins/ManageArtists
        [Authorize(Roles = "Admin")]
        public ActionResult ManageArtists()
        {

            var query = from a in db.Artists
                        select a;
            List<Artist> allArtists = query.ToList();
            return View(allArtists);
        }

        // GET: Admins/EditArtist/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditArtist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist @artist = db.Artists.Find(id);
            return View("~/Views/Admins/EditArtist.cshtml", @artist);
        }

        [Authorize(Roles = "Admin")]
        // POST: Admins/EditArtist/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArtist([Bind(Include = "ArtistID,ArtistName,Featured")] Artist @artist)
        {
            if (ModelState.IsValid)
            {
                //Find associated artist
                Artist artistToChange = db.Artists.Find(@artist.ArtistID);

                artistToChange.ArtistName = @artist.ArtistName;
                artistToChange.Featured = @artist.Featured;


                db.Entry(artistToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageArtists", "Admins");
            }
            return View("~/Views/Admins/EditArtist.cshtml", @artist);
        }

        public SelectList GetAllGenres() //NO GENRE
        {
            //create query to find all committees
            var query = from c in db.Genres
                        orderby c.GenreName
                        select c;
            //execute query and store in list
            List<Genre> allGenres = query.ToList();

            //convert list to selectlist format for HTML
            SelectList allGenresList = new SelectList(allGenres, "GenreID", "GenreName");

            return allGenresList;
        }

        public SelectList GetAllArtists() //NO ARTIST
        {
            //create query to find all artists
            var query = from a in db.Artists
                        orderby a.ArtistName
                        select a;
            //execute query and store in list
            List<Artist> allArtists = query.ToList();

            //convert list to selectlist format for HTML
            SelectList allArtistsList = new SelectList(allArtists, "ArtistID", "ArtistName");

            return allArtistsList;
        }
    }
}