using Hercules.App_Code;
using Hercules.Models;
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
        public ActionResult Index()
        {
            return View();
           
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
       
        public List<DataGridDashboard> DatAnalysis()
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
            return datosplot;
        }

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

            //var zoneslog= new ZoneLogger();
            
            //var zones = zoneslog.zone.Select(pro => new ZoneLogger{
            //    ZoneName = pro.ZoneName,
            //    ZoneID = pro.GetType
            //})

            ZoneLogger zone = new ZoneLogger();

            return Json(zone.zone, JsonRequestBehavior.AllowGet);
        }
    }
}