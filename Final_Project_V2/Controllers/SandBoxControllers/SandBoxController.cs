using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers.SandBoxControllers
{
    public class SandBoxController : Controller
    {
        // GET: SandBox
        public ActionResult Index()
        {
            return View("~/Views/SandBoxViews/SandBox1.cshtml");
        }
    }
}