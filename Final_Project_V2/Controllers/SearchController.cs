﻿using System;
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

        public string SearchResults()
        {
            //string songTitle, string songArtist, string songAlbum, string selectedGenre
            var songTitle = Request.Form["songTitle"];
            var artistName = Request.Form["artistName"];
            var albumName = Request.Form["albumName"];
            var genreArray = Request.Form["genreArray"];
            var ratingFilterType = Request.Form["ratingFilterType"];
            var ratingInput1 = Request.Form["ratingInput1"];
            var ratingInput2 = Request.Form["ratingInput2"];

            var query = from s in db.Songs
                        select s;

            if (songTitle != null && songTitle != "") //check for matching title 
            {
                query = query.Where(s => s.SongTitle.Contains(songTitle));
            } 

            if (artistName != null && artistName != "")
            {
                query = query.Where(s => s.SongArtist.ArtistName.Contains(artistName));
            }

            /*
            if (albumName != null && albumName != "")
            {
                query = query.Where(a => a.SongAlbums.AlbumName.Contains(artistName));
            }
            */

           if (genreArray != null && genreArray != "")
           {
                List<string> GenresToCheck = new List<string>();
                foreach (Char genre in genreArray)
                {
                    GenresToCheck.Add(genre.ToString());
                }     
                foreach(string genre in GenresToCheck)
                {
                    query = query.Where(s => s.SongGenre.GenreName.Contains(genre));
                }
           }

           //check genre dropdown

            query = query.OrderBy(s => s.SongTitle);
            List<Song> SelectedSongs = query.ToList();
            ViewBag.SelectedSongCount = SelectedSongs.Count();
            ViewBag.Display = ("Your search returned" + " " + SelectedSongs.Count() + " " + "results");

            //order query
            //SelectedCustomers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ThenBy(c => c.AverageSale);
            var json = new JavaScriptSerializer().Serialize(SelectedSongs);

            return json;
        }


    }
}