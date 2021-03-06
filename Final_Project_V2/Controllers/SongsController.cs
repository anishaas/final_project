﻿using System;
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
    public class SongsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [Authorize]
        // GET: Songs
        public ActionResult Index()
        {
            return View(db.Songs.ToList());
        }


        // GET: Songs/Details/5
        public ActionResult Details(int? id)
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

        //AUTHORIZE: Managers Only! 
        // GET: /Songs/Create
        public ActionResult Create()
        {
            ViewBag.AllGenres= GetAllGenres();
            return View();
        }

        
        // POST: /Songs/Create
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

        public MultiSelectList GetAllGenres(Song @song)
        {
            //find the list of genres
            var query = from m in db.Genres
                        orderby m.GenreName
                        select m;

            //convert to list and execute query
            List<Genre> allGenres = query.ToList();
            //create list of selected members
            List<Int32> SelectedGenres = new List<Int32>();

            //Loop through list of genres and add GenreId
            foreach (Genre g in @song.SongGenres)
            {
                int ID = g.GenreID;
                SelectedGenres.Add(ID);
            }

            //convert to multiselect
            MultiSelectList allGenresList = new MultiSelectList(allGenres, "GenreID", "GenreName",
            SelectedGenres);

            return allGenresList;
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