using System;
using System.Collections.Generic;
//using Final_Project_V2.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project_V2.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace FinalProject.Controllers.MainControllers
{
    public class DataController : Controller
    {
        //instance of AppDbContext file
        private AppDbContext db = new AppDbContext();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String getGenreData()
        {
            // var genreData = from g in db.Genres select g;

            //return JsonConvert.SerializeObject(genreData);
            return "string";
        }






    }
}