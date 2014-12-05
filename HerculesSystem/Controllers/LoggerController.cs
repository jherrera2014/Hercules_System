using HerculesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerculesSystem.Controllers
{
    public class LoggerController : Controller
    {
        // GET: Logger

       
 
        
        
        public ActionResult ListLogger()
        {
            return View();
        }


        
        
        
        
        
        
        
        public JsonResult GetLogger()
        {
            ZoneLogger zone = new ZoneLogger();
            var logger = zone.logger.AsQueryable();
            

            return Json(logger.Select(o => new { LoggerID = o.ID, LoggerName = o.LoggerSMSNumber , SitiesID  = o.SitiesID }), JsonRequestBehavior.AllowGet);

        }
    }
}