using HerculesSystem.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace HerculesSystem.Controllers
{
    public class LoggerController : Controller
    {
        // GET: Logger

        
       
        public ActionResult ListLogger()
        {
            

            return View();
        }


        public ActionResult Loading()
        {


            return View();
        }



        public ActionResult Index(string ID)
        {
            ViewData["id"] = ID;
            Session["id"] = ViewData["id"];
            
            return View();
        }

        public ActionResult DetailButton(string ID)
        {
            ViewData["id"] = ID;
            
            
            return RedirectToAction("Index", new { id = ID });
        }

        public ActionResult FilterButton([DataSourceRequest] DataSourceRequest request, int? zone, int?logger)
        {

            //return RedirectToAction("ListLogger", new { zone = zone,logger = logger });
            return GetView(request);
        }



          private IEnumerable<dynamic> GetData()
        {
            var db = new hercules_dbEntities();
            var zone = new ZoneLogger();
            var result = from a in db.loggers
                         join b in db.sites
                             on new { emp = a.ID } equals new { emp = b.LoggerID }

                         select new
                            {
                                ID = a.ID,
                                LoggerSMSNumber = a.LoggerSMSNumber,
                                BatteryLevel = a.BatteryLevel,
                                LastCallIn = a.LastCallIn,
                                LoggerSerialNumber = a.LoggerSerialNumber,
                                LoggerType = a.LoggerType,
                                SignalLevel = a.SignalLevel,
                                Adress = b.Address,
                                LoggerID = a.ID
                            };

            return result ;
        }

          public ActionResult Read([DataSourceRequest] DataSourceRequest request)
          {
              return GetView(request);
          }

          private JsonResult GetView(DataSourceRequest request)
          {
              return Json(GetData().ToDataSourceResult(request));
          }

          [HttpPost]
          public ActionResult RefreshSelfUpdatingPartial()
          {

              // Setting the Models Content
              // ...

              return PartialView("_SelfUpdatingPartial");
          }
       
    }
  
}