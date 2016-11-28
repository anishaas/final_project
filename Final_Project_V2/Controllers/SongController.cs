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

namespace Final_Project_V2.Controllers
{
    public class SongController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [Authorize]
        // GET: Songs
        public ActionResult Index()
        {
            return View(db.Songs.ToList());
        }


        // GET: Songs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song songs = db.Songs.Find(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }


        // GET: Songs/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongID,SongTitle,SongPrice,SongArtist,SongGenres,SongAlbums")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //need to make sure that SongArtist, SongGenres, SongAlbums are added and are valid selections
            return View(song);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}