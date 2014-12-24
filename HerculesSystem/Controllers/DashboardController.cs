﻿using Hercules.App_Code;
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
using Kendo.Mvc.Extensions;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Diagnostics;

namespace Hercules.Controllers
{


  
    
  
    public class DashboardController : Controller
    {
        // GET: Dashboard

        List<GoogleMarker> datamap;
        List<GoogleMarker> datamap1;

        public class GoogleMarker
        {

            public double LatEast { get; set; }

            public double LongNorth { get; set; }

            public string Address { get; set; }

            public string ZoneName { get; set; }

            public string Notes { get; set; }

            public int ZoneID { get; set; }

            public double LatEast1 { get; set; }

            public double LongNorth1 { get; set; }


        }





        public List<GoogleMarker> DatAnalysis(int data)
        {

            datamap = new List<GoogleMarker>();

            var dat = data;



            DataSet ds = new DataSet();



            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());



            {

                using (SqlCommand cmd1 = new SqlCommand())
                {



                    cmd1.CommandText = @"   SELECT  LatEast,LongNorth ,lg.Notes , ZoneName,Address From alarms a Inner Join loggers lg on a.ID =@ID JOIN zone t  ON a.LoggerSMSNumber = lg.LoggerSMSNumber JOIN sites s ON lg.ID = s.LoggerID Where s.ZoneID = t.ID ";

                    cmd1.Parameters.Add("@ID", SqlDbType.Int);

                    cmd1.Parameters["@ID"].Value = data;

                    cmd1.Connection = con1;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                    {

                        da.Fill(ds, "MapsGraph");

                    }

                }

            }

            if (ds != null)
            {

                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables["MapsGraph"].Rows.Count > 0)
                    {



                        foreach (DataRow dr in ds.Tables["MapsGraph"].Rows)
                        {

                            datamap.Add(new GoogleMarker

                            {

                                LatEast = Convert.ToDouble(dr["LatEast"], System.Globalization.CultureInfo.InvariantCulture),

                                LongNorth = Convert.ToDouble(dr["LongNorth"], System.Globalization.CultureInfo.InvariantCulture),

                                Notes = (dr["Notes"].ToString()),

                                Address = (dr["Address"].ToString()),

                                ZoneName = (dr["ZoneName"].ToString())

                            });


                        }

                    }

                }


            }

            return datamap;

        }

        public List<GoogleMarker> DatMapaZona()
        {

            datamap1 = new List<GoogleMarker>();

        



            DataSet ds = new DataSet();



            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());



            {

                using (SqlCommand cmd1 = new SqlCommand())
                {



                    cmd1.CommandText = @" SELECT LatEast,LongNorth ,ZoneID From sites WHERE  LatEast IS NOT NULL and LongNorth IS NOT NULL ";

              

                    cmd1.Connection = con1;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                    {

                        da.Fill(ds, "MapsGraph1");

                    }

                }

            }

            if (ds != null)
            {

                if (ds.Tables.Count > 0)
                {

                    if (ds.Tables["MapsGraph1"].Rows.Count > 0)
                    {



                        foreach (DataRow dr in ds.Tables["MapsGraph1"].Rows)
                        {
                           
                            
                            
                            Debug.WriteLine((dr["LatEast"].ToString()));
                            
                            
                            datamap1.Add(new GoogleMarker

                            {

                                
                             
                                
                                LatEast1 = Convert.ToDouble(dr["LatEast"].ToString(), System.Globalization.CultureInfo.InvariantCulture),

                                LongNorth1 = Convert.ToDouble(dr["LongNorth"].ToString(), System.Globalization.CultureInfo.InvariantCulture),

                                ZoneID =  Convert.ToInt16(dr["ZoneID"], System.Globalization.CultureInfo.InvariantCulture),
                                   
                               

                            });

                             
                        }

                    }

                }


            }

            return datamap1;

        }



        
        public ActionResult Index()
        {
            string data1 = Convert.ToString(Session["idmap"]);
            string data = Request["param1"];
            int datval = Convert.ToInt16(data1);
            

            Debug.WriteLine("llego" + data1);
            string prueba = "p1";

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(DatAnalysis(datval));
        
            return Json(DatAnalysis(datval), JsonRequestBehavior.AllowGet);
           
        }
        public ActionResult List(string ID)
        {

       
            return View();
           
        }


        public ActionResult MapaAll()
        {


            var json = Newtonsoft.Json.JsonConvert.SerializeObject(DatMapaZona());





            return Json(DatMapaZona(), JsonRequestBehavior.AllowGet);

        }


        public ActionResult MostarMapa()
        {


            return View();

        }

        public ActionResult SparkLine(){

            return View();
        }

        public ActionResult DatosMostrar(string ID)
        {

            ViewData["id"] = ID;
            Session["idmap"] = ViewData["id"];
            return View();

        }

        
        
        
        
        
        
        public ActionResult Detail(string ID)
        {

            ViewData["id"] = ID;
          
            
            return RedirectToAction("DatosMostrar", new { id = ID });

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
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return GetView(request);
        }

        private JsonResult GetView(DataSourceRequest request)
        {
            return Json(GetData().ToDataSourceResult(request));
        }
        private IEnumerable<dynamic> GetData()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            //var zone = new ZoneLogger();
            var result = from a in db.alarms
                         join b in db.alarmTypes
                             on new { emp = a.MessageID } equals new { emp = b.AlarmTypeId }
                         join c in db.loggers
                             on new { emp = a.LoggerSMSNumber } equals new { emp = c.LoggerSMSNumber}
                         select new
                         {
                             IDAlarm = a.ID,
                             IDLogger = c.ID,
                             AlarmType = b.AlarmType,
                             LoggerSerialNumber = c.LoggerSerialNumber,
                             LoggerType = c.LoggerType,
                             LoggerSMS = c.LoggerSMSNumber
                         };

            var loggerName = from a in db.loggers
                            join b in db.sites
                                on new { emp = a.ID } equals new { emp = b.LoggerID }

                            select new
                            {
                                ID = a.ID,
                                IDZone = b.ZoneID,
                                LoggerName = b.Address
                            };

            var finaltable = from a in result
                             join b in loggerName
                             on new {emp = a.IDLogger} equals new {emp = b.ID}
                             select new
                             {
                                 IDAlarm = a.IDAlarm,
                                 IDLogger = a.IDLogger,
                                 AlarmType = a.AlarmType,
                                 LoggerSerialNumber = a.LoggerSerialNumber,
                                 LoggerType = a.LoggerType,
                                 LoggerSMS = a.LoggerSMS,
                                 LoggerName = b.LoggerName
                             };

            return finaltable;
        }

        public JsonResult GetZone()
        {
            ZoneLogger zone = new ZoneLogger();
            return Json(zone.zone, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetLogger(int? ZoneDropDownList)
        {
            //ZoneLogger zone = new ZoneLogger();
            //var logger = zone.logger.AsQueryable();

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

    
    }
}