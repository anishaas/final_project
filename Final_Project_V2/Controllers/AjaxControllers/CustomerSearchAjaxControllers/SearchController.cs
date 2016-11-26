using System;
using System.Collections.Generic;
//using Final_Project_V2.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            //db.Configuration.ProxyCreationEnabled = false;
            //string songTitle, string songArtist, string songAlbum, string selectedGenre
            var songTitle = Request.Form["songTitle"];
            var artistName = Request.Form["songArtist"];
            var albumName = Request.Form["songAlbum"];
            var genreArray = Request.Form["genreArray"];
            var ratingFilterType = Request.Form["ratingFilterType"];
            var ratingInput1 = Request.Form["ratingInput1"];
            var ratingInput2 = Request.Form["ratingInput2"];

            //var query = from s in db.Songs
            //            select s;

            var songsQuery = from song in db.Songs
                          select new
                          {
                              SongTitle = song.SongTitle,
                              SongPrice = song.SongPrice,
                              ArtistName = song.SongArtist.ArtistName,
                              Featured = song.Featured, 
                              SongGenres = song.SongGenres,
                              SongAlbums = song.SongAlbums
                          };

            if (songTitle != null && songTitle != "") //check for matching title 
            {
                songsQuery = songsQuery.Where(s => s.SongTitle.Contains(songTitle));
            }

            if (artistName != null && artistName != "")
            {
                songsQuery = songsQuery.Where(s => s.ArtistName.Contains(artistName));
            }

            if (albumName != null && albumName != "")
            {

                /*@PF
                 *Thank God for this stack exchange post.
                 *http://codereview.stackexchange.com/questions/93973/linq-query-that-filters-elements-from-a-list-of-object?newreg=7f3e74d0f2764cc6ac774e15cb92f16a
                 *(Explains how to query a list within a list using linq)
                 */
                songsQuery = songsQuery
                .Where(sq => sq.SongAlbums
                            .Any(sa => sa.AlbumName.Contains(albumName)));
            }


            if (genreArray != null && genreArray != "")
            {

                string[] genreStrings = genreArray.Split(',');

                List<string> GenresToCheck = new List<string>();


                foreach (string genreString in genreStrings)
                {
                    if (genreString != "")
                    {
                        GenresToCheck.Add(genreString);
                    }
    
                }

                var genreCount = GenresToCheck.Count();

                //Completely unoptimal code. But it's functional.
                if (genreCount == 1)
                {
                    var genre1 = GenresToCheck[0];
                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) 
                    ));
                }else if (genreCount == 2)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2)
                    ));
                }
                else if (genreCount == 3)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3)
                    ));
                }
                else if (genreCount == 4)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) 
                    ));
                }
                else if (genreCount == 5)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5)
                    ));
                }
                else if (genreCount == 6)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6)
                    ));
                }
                else if (genreCount == 7)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    
                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) 
                    ));
                }
                else if (genreCount == 8)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];


                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) 
                    ));
                }
                else if (genreCount == 9)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];
                    var genre9 = GenresToCheck[8];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) ||
                            sg.GenreName.Contains(genre9)
                    ));
                }
                else if (genreCount == 10)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];
                    var genre9 = GenresToCheck[8];
                    var genre10 = GenresToCheck[9];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) ||
                            sg.GenreName.Contains(genre9) ||
                            sg.GenreName.Contains(genre10)
                    ));
                }
                else if (genreCount == 11)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];
                    var genre9 = GenresToCheck[8];
                    var genre10 = GenresToCheck[9];
                    var genre11 = GenresToCheck[10];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) ||
                            sg.GenreName.Contains(genre9) ||
                            sg.GenreName.Contains(genre10) ||
                            sg.GenreName.Contains(genre11)
                    ));
                }
                else if (genreCount == 12)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];
                    var genre9 = GenresToCheck[8];
                    var genre10 = GenresToCheck[9];
                    var genre11 = GenresToCheck[10];
                    var genre12 = GenresToCheck[11];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) ||
                            sg.GenreName.Contains(genre9) ||
                            sg.GenreName.Contains(genre10) ||
                            sg.GenreName.Contains(genre11) ||
                            sg.GenreName.Contains(genre12)
                    ));
                }
                else if (genreCount == 13)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];
                    var genre9 = GenresToCheck[8];
                    var genre10 = GenresToCheck[9];
                    var genre11 = GenresToCheck[10];
                    var genre12 = GenresToCheck[11];
                    var genre13 = GenresToCheck[12];


                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) ||
                            sg.GenreName.Contains(genre9) ||
                            sg.GenreName.Contains(genre10) ||
                            sg.GenreName.Contains(genre11) ||
                            sg.GenreName.Contains(genre12) ||
                            sg.GenreName.Contains(genre13)
                    ));
                }
                else if (genreCount == 14)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];
                    var genre9 = GenresToCheck[8];
                    var genre10 = GenresToCheck[9];
                    var genre11 = GenresToCheck[10];
                    var genre12 = GenresToCheck[11];
                    var genre13 = GenresToCheck[12];
                    var genre14 = GenresToCheck[13];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) ||
                            sg.GenreName.Contains(genre9) ||
                            sg.GenreName.Contains(genre10) ||
                            sg.GenreName.Contains(genre11) ||
                            sg.GenreName.Contains(genre12) ||
                            sg.GenreName.Contains(genre13) ||
                            sg.GenreName.Contains(genre14)
                    ));
                }
                else if (genreCount == 15)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];
                    var genre5 = GenresToCheck[4];
                    var genre6 = GenresToCheck[5];
                    var genre7 = GenresToCheck[6];
                    var genre8 = GenresToCheck[7];
                    var genre9 = GenresToCheck[8];
                    var genre10 = GenresToCheck[9];
                    var genre11 = GenresToCheck[10];
                    var genre12 = GenresToCheck[11];
                    var genre13 = GenresToCheck[12];
                    var genre14 = GenresToCheck[13];
                    var genre15 = GenresToCheck[14];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4) ||
                            sg.GenreName.Contains(genre5) ||
                            sg.GenreName.Contains(genre6) ||
                            sg.GenreName.Contains(genre7) ||
                            sg.GenreName.Contains(genre8) ||
                            sg.GenreName.Contains(genre9) ||
                            sg.GenreName.Contains(genre10) ||
                            sg.GenreName.Contains(genre11) ||
                            sg.GenreName.Contains(genre12) ||
                            sg.GenreName.Contains(genre13) ||
                            sg.GenreName.Contains(genre14) ||
                            sg.GenreName.Contains(genre15)

                    ));
                }
                //TODO Finish the rest of this code...
                else if (genreCount == 16)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4)
                    ));
                }
                else if (genreCount == 17)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4)
                    ));
                }
                else if (genreCount == 18)
                {
                    var genre1 = GenresToCheck[0];
                    var genre2 = GenresToCheck[1];
                    var genre3 = GenresToCheck[2];
                    var genre4 = GenresToCheck[3];

                    songsQuery = songsQuery
                    .Where(sq => sq.SongGenres
                    .Any(sg => sg.GenreName.Contains(genre1) ||
                            sg.GenreName.Contains(genre2) ||
                            sg.GenreName.Contains(genre3) ||
                            sg.GenreName.Contains(genre4)
                    ));
                }


                /*
                foreach (string genre in GenresToCheck)
                {
                    //TODO: Fix now that song genres is a list
                    //query = query.Where(s => s.SongGenre.GenreName.Contains(genre));
                }
                */
            }

            return JsonConvert.SerializeObject(songsQuery);


            /*


           if (genreArray != null && genreArray != "")
           {
                List<string> GenresToCheck = new List<string>();
                foreach (Char genre in genreArray)
                {
                    GenresToCheck.Add(genre.ToString());
                }     
                foreach(string genre in GenresToCheck)
                {
                    //TODO: Fix now that song genres is a list
                    //query = query.Where(s => s.SongGenre.GenreName.Contains(genre));
                }
           }

           /*
           if (ratingFilterType != null && ratingFilterType != "" && ratingInput1 != null && ratingInput1 != "" && ratingInput2 != null && ratingInput2 != "")
            {
            1) Greater than code
            2) Less than code
            3)Between              
            }
            */
           //check genre dropdown
           /*
            query = query.OrderBy(s => s.SongTitle);
            List<Song> SelectedSongs = query.ToList();
            ViewBag.SelectedSongCount = SelectedSongs.Count();
            ViewBag.Display = ("Your search returned" + " " + SelectedSongs.Count() + " " + "results");

            //order query
            //SelectedCustomers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ThenBy(c => c.AverageSale);
            //var json = new JavaScriptSerializer().Serialize(SelectedSongs);
            var jsonTest = JsonConvert.SerializeObject(SelectedSongs);
            //string combinedString = String.Join(",", SelectedSongs);
            //return new JsonResult() { Data = songs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return jsonTest;
            */
        }


    }
}