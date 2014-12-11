using Hercules.App_Code;
using Hercules.Models;
using HerculesSystem;
using HerculesSystem.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Hercules.Controllers
{


  
    
  
    public class DashboardController : Controller
    {
        // GET: Dashboard

        public static IList<GoogleMarker> GetMarkers()
        {
            var googleMarkers = new List<GoogleMarker>
                                    {
                                                                         
                                        
                                        
                                        new GoogleMarker
                                            {
                                                SiteName = "Limachess",
                                                Latitude =-33.009901,
                                                Longitude = -71.258046,
                                                InfoWindow = "FW125001U"
                                            },
                                        new GoogleMarker
                                            {
                                                SiteName = "Villa Alemana",
                                                Latitude =  -33.048392,
                                                Longitude = -71.363220   ,
                                                InfoWindow = "MultilogLX"
                                            },
                                        new GoogleMarker
                                            {
                                                SiteName = "Real Curimon",
                                          Latitude =  -33.018280,
                                                Longitude = -71.494132 ,
                                                InfoWindow = "FW125001U"
                                            },
                                   
                                    new GoogleMarker
                                            {
                                                SiteName = "Hijuelas",
                                          Latitude = -32.798778,
                                                Longitude =  -71.143029 ,
                                                InfoWindow = "MultilogLX"
                                            },
                                    
                                    
                                     new GoogleMarker
                                            {
                                                SiteName = "Cabildo",
                                          Latitude = -32.425048,
                                                Longitude = -71.075179 ,
                                                InfoWindow = "FW125001U"
                                            },
                                    
                                     new GoogleMarker
                                            {
                                                SiteName = "Chincolco",
                                          Latitude = -32.220642,
                                                Longitude = -70.834928 ,
                                                InfoWindow = "FW125001U"
                                            },
                                    
                                    new GoogleMarker
                                            {
                                                SiteName = "La Ligua",
                                          Latitude =  -32.452033,
                                                Longitude =  -71.231773 ,
                                                InfoWindow = "MultilogLX"
                                            },
                                     
                                     new GoogleMarker
                                            {
                                                SiteName = "La Cruz",
                                          Latitude =  -32.825263,
                                                Longitude =  -71.228107 ,
                                                InfoWindow = "MultilogLX"
                                            },
                                     
                                    
                                    
                                    
                                    
                                    
                                    };

            return googleMarkers;
        }

        
        public ActionResult Index()
        {
            return Json(MapsController.GetMarkers(), JsonRequestBehavior.AllowGet);
           
        }
        public ActionResult List()
        {
            return View();
           
        }

        public ActionResult Detail()
        {
            return View();

        }


        List<DataGridDashboard> datosplot;

        public JsonResult GetAlarm()
        {
            datosplot = new List<DataGridDashboard>();
            AdminBd bd = new AdminBd();
            DataTable dt = new DataTable();
            ArrayList list = new ArrayList();
            bd.list_alert_logger(ref dt, list);

            foreach (DataRow dr in dt.Rows)
            {
                datosplot.Add(new DataGridDashboard
                {
                    LoggerSmSNumber = dr[0].ToString(),
                    AlarmText = dr[1].ToString(),
                    MessageID = dr[2].ToString()

                });
               
            }
            DataSourceResult dato = new DataSourceResult();
            dato.Data = datosplot;
            dato.Total = datosplot.Count();


            return Json(dato);
        }

        public JsonResult GetZone()
        {
            ZoneLogger zone = new ZoneLogger();
            return Json(zone.zone, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSites(int? ZoneDropDownList)
        {
            ZoneLogger zone = new ZoneLogger();
            var sites = zone.sites.AsQueryable();
            if (ZoneDropDownList != null)
            {
                sites = sites.Where(p => p.ZoneID == ZoneDropDownList);

                return Json(sites.Select(p => new { SiteName = p.Address, SiteID = p.ID }), JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null);
            
          
        }
        public JsonResult GetLogger(int? ZoneDropDownList)
        {
            ZoneLogger zone = new ZoneLogger();
            var logger = zone.logger.AsQueryable();

            DataClasses1DataContext db = new DataClasses1DataContext();

            var jointable = from a in db.loggers
                         join b in db.sites
                             on new { emp = a.ID } equals new { emp = b.LoggerID }

                         select new
                         {
                             ID = a.ID,
                             IDZone = b.ZoneID,
                             LoggerName = b.Address
                         };

            if (ZoneDropDownList != null)
            {
                jointable = jointable.Where(o => o.IDZone == ZoneDropDownList);
                return Json(jointable.Select(o => new { LoggerID = o.ID, LoggerName = o.LoggerName }), JsonRequestBehavior.AllowGet);

            }
            else
                return Json(null);

            }

        public void FilterButton(Object sender, EventArgs e)
        {
            string value_zone= "";

           
        }
    }
}