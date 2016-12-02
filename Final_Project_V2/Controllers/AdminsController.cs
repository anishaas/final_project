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

        // GET: Admins/SongDetails
        public ActionResult SongDetails(int id)
        {
            //find respective song
            List<Song> FoundSongs = db.Songs.Include(s => s.SongAlbums).Include(s => s.SongGenres).ToList();
            Song @song = FoundSongs.FirstOrDefault(x => x.SongID == id);
            //List<Song> SongsFound = db.Songs.Include(s => s.SongAlbums).ToList();
            //Song @song = FoundSongs.FirstOrDefault(x => x.SongID == id);
            //render song details page
            return View("~/Views/Songs/Details.cshtml", @song);
        }

        // GET: Admins/AlbumDetails
        public ActionResult AlbumDetails(int id)
        {
            //find respective album
            Album @album = db.Albums.Find(id);
            //render album details page
            return View("~/Views/Albums/Details.cshtml", @album);
        }

        // GET: Admins/ArtistDetails
        public ActionResult ArtistDetails(int id)
        {
            //find respective artist
            Artist @artist = db.Artists.Find(id);
            //render artist details page
            return View("~/Views/Artists/Details.cshtml", @artist);
        }

        // GET: Admins/CreateSong
        public ActionResult CreateSong()
        {
            ViewBag.AllGenres = GetAllGenres();
            ViewBag.AllArtists = GetAllArtists();
            ViewBag.AllAlbums = GetAllAlbums();
            return View();
        }

        // POST: Admins/CreateSong
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateSong([Bind(Include = "SongID,SongTitle,SongPrice,Featured,SongArtist")] Song @song, int[] SelectedGenres)
        {
            var query = from s in db.Songs
                        select s;
            query.Where(s => s.SongTitle == @song.SongTitle);
            List<Song> potentialDuplicateSongs = query.ToList();

            //foreach (songArtist )

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
                //if (SelectedArtists != null)
                //{
                //    foreach (int Id in SelectedArtists)
                //    {
                //        Artist artistToAdd = db.Artists.Find(Id);
                //        @song.SongArtists.Add(artistToAdd);
                //    }
                //}
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
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        // POST: Admins/CreateAlbum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAlbum([Bind(Include = "AlbumID,AlbumName,AlbumPrice,Featured")] Album @album, int[] SelectedGenres)
        {
            //Validation
            //Check that the album's songs exist in the database

            if (ModelState.IsValid)
            {
                //add genres
                if (SelectedGenres != null)
                {
                    foreach (int Id in SelectedGenres)
                    {
                        Genre genreToAdd = db.Genres.Find(Id);
                        @album.AlbumGenres.Add(genreToAdd);
                    }
                }
                db.Albums.Add(@album);
                db.SaveChanges();
                return RedirectToAction("ManageAlbums");
            }

            return View();
        }

        // GET: Admins/CreateArtist
        public ActionResult CreateArtist()
        {
            ViewBag.AllGenres = GetAllGenres();
            return View();
        }

        // POST: Admins/CreateArtist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "ArtistID,ArtistName,Featured")] Artist @artist, int[] SelectedGenres)
        {
            if (ModelState.IsValid)
            {
                //add genres
                if (SelectedGenres != null)
                {
                    foreach (int Id in SelectedGenres)
                    {
                        Genre genreToAdd = db.Genres.Find(Id);
                        @artist.ArtistGenres.Add(genreToAdd);
                    }
                }
                db.Artists.Add(@artist);
                db.SaveChanges();
                return RedirectToAction("ManageArtists");
            }

            return View(artist);
        }

        //GET: Admins/ManageEmployees
        [Authorize(Roles = "Admin")]
        public ActionResult ManageEmployees()
        {

            var query = from c in db.Users
                        select c;
            List<AppUser> allEmployees = query.ToList();

            String EmployeeGUID = db.AppRoles.FirstOrDefault(r => r.Name == "Employee").Id;
            allEmployees = db.Users.Where(x => x.Roles.Any(s => s.RoleId == EmployeeGUID)).ToList();
            return View(allEmployees);
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

        // GET: Admins/EditEmployee/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditEmployee(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser @employee = db.Users.Find(id);
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Admins/EditEmployee/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee([Bind(Include = "Id,Phone,DisabledEmployee,Password")] AppUser @employee)
        //LastName,FirstName,EmailAddress,CCType1,CCNumber1,CCType2,CCNumber2
        {
            if (ModelState.IsValid)
            {
                //Find associated customer
                AppUser employeeToChange = db.Users.Find(@employee.Id);

                employeeToChange.Email = @employee.Email;
                employeeToChange.Phone = @employee.Phone;
                employeeToChange.Password = @employee.Password;
                employeeToChange.DisabledEmployee = @employee.DisabledEmployee;
                
                db.Entry(employeeToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageEmployees", "Admins");
            }
            return View("~/Views/Employees/EditCustomer.cshtml", @employee);
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
            if (@song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllGenres = GetAllGenres(@song);
            ViewBag.AllAlbums = GetAllAlbums(@song);
            return View("~/Views/Admins/EditSong.cshtml", @song);
        }

        [Authorize(Roles = "Admin")]
        // POST: Admins/EditSong/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSong([Bind(Include = "SongID,SongTitle,SongPrice,Featured,SongArtist,SongDiscount,SongDiscountEnabled")] Song @song, int[] SelectedGenres, int[] SelectedAlbums)
        {
            if (ModelState.IsValid)
            {
                //Find song to change
                Song songToChange = db.Songs.Find(@song.SongID);

                songToChange.SongTitle = @song.SongTitle;
                songToChange.SongPrice = @song.SongPrice;
                songToChange.SongArtist = @song.SongArtist;
                songToChange.Featured = @song.Featured;
                songToChange.SongDiscount = @song.SongDiscount;

                //first, remove any genres
                songToChange.SongGenres.Clear();
                songToChange.SongAlbums.Clear();

                if (SelectedGenres != null)
                {
                    foreach (int Id in SelectedGenres)
                    {
                        Genre genreToAdd = db.Genres.Find(Id);
                        songToChange.SongGenres.Add(genreToAdd);
                    }
                }
                if (SelectedAlbums != null)
                {
                    foreach (int Id in SelectedAlbums)
                    {
                        Album albumToAdd = db.Albums.Find(Id);
                        songToChange.SongAlbums.Add(albumToAdd);
                    }
                }
                songToChange.SongDiscountEnabled = @song.SongDiscountEnabled;
                if (@song.SongDiscountEnabled == true)
                {
                    songToChange.SongDiscountedPrice = @song.SongPrice - @song.SongDiscount;
                }

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
        public ActionResult EditAlbum([Bind(Include = "AlbumID,AlbumName,AlbumPrice,Featured,AlbumArtist,AlbumDiscount,AlbumDiscountEnabled")] Album @album)
        //LastName,FirstName,EmailAddress,CCType1,CCNumber1,CCType2,CCNumber2
        {
            if (ModelState.IsValid)
            {
                //Find associated customer
                Album albumToChange = db.Albums.Find(@album.AlbumID);

                albumToChange.AlbumName = @album.AlbumName;
                albumToChange.AlbumPrice = @album.AlbumPrice;
                //albumToChange.AlbumGenres = @album.SelectedGenres; 
                albumToChange.AlbumDiscount = @album.AlbumDiscount;
                albumToChange.AlbumDiscountEnabled = @album.AlbumDiscountEnabled;
                if (@album.AlbumDiscountEnabled == true)
                {
                    albumToChange.AlbumDiscountedPrice = @album.AlbumPrice - @album.AlbumDiscount;
                }


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

        public MultiSelectList GetAllGenres() //NO GENRE
        {
            //create query to find all genres
            var query = from g in db.Genres
                        orderby g.GenreName
                        select g;
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

        public MultiSelectList GetAllAlbums() //NO ALBUMS
        {
            //create query to find all albums
            var query = from a in db.Albums
                        orderby a.AlbumName
                        select a;
            //execute query and store in list
            List<Album> allAlbums = query.ToList();

            //convert list to selectlist format for HTML
            SelectList allAlbumsList = new SelectList(allAlbums, "AlbumID", "AlbumName");

            return allAlbumsList;
        }

        public MultiSelectList GetAllAlbums(Song @song) 
        {
            //create query to find all albums
            var query = from a in db.Albums
                        orderby a.AlbumName
                        select a;
            //execute query and store in list
            List<Album> allAlbums = query.ToList();
            List<Int32> SelectedAlbums = new List<Int32>();

            foreach (Album a in @song.SongAlbums)
            {
                SelectedAlbums.Add(a.AlbumID);
            }

            //convert list to multiselect list format for HTML
            MultiSelectList allAlbumsList = new MultiSelectList(allAlbums, "AlbumID", "AlbumName", SelectedAlbums);
            return allAlbumsList;
        }

        public MultiSelectList GetAllGenres(Song @song)
        {
            //find the list of genres
            var query = from g in db.Genres
                        orderby g.GenreName
                        select g;

            List<Genre> allGenres = query.ToList();
            List<Int32> SelectedGenres = new List<Int32>();

            //Loop through list of genres add GenreId
            foreach (Genre g in @song.SongGenres)
            {
                SelectedGenres.Add(g.GenreID);
            }

            //convert to multiselect
            MultiSelectList allGenresList = new MultiSelectList(allGenres, "GenreID", "GenreName", SelectedGenres);
            return allGenresList;
        }




    }
}