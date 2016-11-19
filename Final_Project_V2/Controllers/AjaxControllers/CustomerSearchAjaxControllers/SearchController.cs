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

       // [HttpPost]
        public ActionResult searchbySongTitle()
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

            return View ("~/Views/SandBoxViews/Search/SongSearch/customerSongSearch.cshtml");

            //Display message to users
            //if (SelectedSongs == null)
            //{
            //    return "No songs found based on your search";
            //}
            //else
            //{
            //    return "Successful search";
            //}
        }
    }
}