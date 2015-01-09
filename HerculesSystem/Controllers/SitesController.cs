using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerculesSystem.Controllers
{
    public class SitesController : Controller
    {
        // GET: Sites
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            
            return View();
        }

        public ActionResult Ghaph()
        {


            return null;

        }
    }
}