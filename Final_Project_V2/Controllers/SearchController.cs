using System;
using System.Collections.Generic;
using Final_Project_V2.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;
using System.Web.Script.Serialization;

namespace FinalProject.Controllers.MainControllers
{
    public class SearchController : Controller
    {
        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String searchbySongTitle()
        {
            var songTitle = Request.Form["songTitle"];
            //var songArtist = Request.Form["songArtist"];

            //Find relevant songs
            var query = from s in db.Songs
                        select s;
            query = query.Where(s => s.SongTitle.Contains(songTitle));
            List<Song> SelectedSongs = query.ToList();

            //convert songs objects to JSON for frontend
            var json = new JavaScriptSerializer().Serialize(SelectedSongs);

            //Display message to users
            if (SelectedSongs == null)
            {
                return "No songs found based on your search";
            }
            else
            {
                return "Successful search";
            }
        }

        public ActionResult searchbyAlbumTitle()
        {
            var albumTitle = Request.Form["albumTitle"];
            //var songArtist = Request.Form["songArtist"];

            //Find relevant songs
            var query = from a in db.Albums
                        select a;
            query = query.Where(a => a.AlbumName.Contains(albumTitle));
            List<Album> SelectedAlbums = query.ToList();

            //convert songs objects to JSON for frontend
            var json = new JavaScriptSerializer().Serialize(SelectedAlbums);

            return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");
        }

        public string searchbyArtistName()
        {
            var artistName= Request.Form["artistName"];
            //var songArtist = Request.Form["songArtist"];

            //Find relevant songs
            var query = from a in db.Artists
                        select a;
            query = query.Where(a => a.ArtistName.Contains(artistName));
            List<Artist> SelectedArtists = query.ToList();

            //convert songs objects to JSON for frontend
            var json = new JavaScriptSerializer().Serialize(SelectedArtists);

            //return View("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");

            //Display message to users
            if (SelectedArtists == null)
            {
                return "No artists found based on your search";
            }
            else
            {
                return "Successful search";
            }
        }

        public SelectList GetAllGenres()
        {
            var query = from g in db.Genres
                        orderby g.GenreName
                        select g;
            List<Genre> GenreList = query.Distinct().ToList();

            //Add in choice for not selecting a frequency
            Genre NoChoice = new Genre() { GenreID = 0, GenreName = "No Genre" };
            GenreList.Add(NoChoice);
            SelectList AllGenres = new SelectList(GenreList.OrderBy(g => g.GenreName), "GenreID", "GenreName");
            return AllGenres;
        }

        public string SearchResults(string songTitle, string songArtist, string songAlbum, string selectedGenre)
        {
            ViewBag.AllGenres = GetAllGenres();
            var query = from s in db.Songs
                        select s;
            if (songTitle != null || songTitle != "") 
            {
                query = query.Where(s => s.SongTitle.Contains(songTitle) && s.SongArtist.ArtistName.Contains(songArtist));
            }
            //check genre dropdown
            if (selectedGenre == null) // they chose "no genre" from the drop-down
            {
                //replace statement with AJAX request
                ViewBag.SelectedGenre = "No genre was selected";
            }
            else //genre was selected
            {
                List<Genre> AllGenres = db.Genres.ToList();
                Genre GenreToDisplay = AllGenres.Find(g => g.GenreName == selectedGenre);
                ViewBag.Genre = "The selected genre is " + GenreToDisplay.GenreName;
                query = query.Where(s => s.SongGenre.GenreName == selectedGenre);
            }
            

           
            query = query.OrderBy(s => s.SongTitle);
            List<Song> SelectedSongs = query.ToList();
            ViewBag.SelectedSongCount = SelectedSongs.Count();
            ViewBag.Display = ("Your search returned" + " " + SelectedSongs.Count() + " " + "results");

            //order query
            //SelectedCustomers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ThenBy(c => c.AverageSale);


            return "hi";
        }


    }
}