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
        public ActionResult EditSong([Bind(Include = "SongID,SongTitle,SongPrice,Featured,SongArtist")] Song @song)
        //LastName,FirstName,EmailAddress,CCType1,CCNumber1,CCType2,CCNumber2
        {
            if (ModelState.IsValid)
            {
                //Find associated customer
                Song songToChange = db.Songs.Find(@song.SongID);

                songToChange.SongTitle = @song.SongTitle;
                songToChange.SongPrice = @song.SongPrice;
                songToChange.SongArtist = @song.SongArtist;
                songToChange.Featured = @song.Featured;

                db.Entry(songToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageSongs", "Admin");
            }
            return View("~/Views/Admins/EditSong.cshtml", @song);
        }
    }
}