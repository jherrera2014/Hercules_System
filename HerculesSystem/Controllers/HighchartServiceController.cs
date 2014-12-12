using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Point = DotNet.Highcharts.Options.Point;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Collections;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script;
using System.Web.Script.Serialization;
using  System.Runtime.InteropServices;


namespace Hercules.Controllers
{
    public class HighchartServiceController : Controller
    {
        // GET: HighchartService
         List<DataDnk> datosplot;
         int capdata;

         DataSet ds;
         public class DataDnk
        {
            public long datetime { get; set; }
            public double c1pressure { get; set; }

            public double c2flow { get; set; }

            public double c3pressure { get; set; }


        }


        public virtual int AJAXRequest(int param1)
	{
        Debug.WriteLine(param1);

        capdata = param1;
        Session["datodia"] = param1;
        return (param1);
	}

        public long ToJsonTicks(DateTime value)
        {
            return (value.ToUniversalTime().Ticks - ((new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks)) / 10000;
        }



         public List<DataDnk> DatAnalysis()
         {
             datosplot = new List<DataDnk>();
             Debug.WriteLine("llego" + Session["datodia"]);

             DataSet ds = new DataSet();

             SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
             
             
             
            
      
             
             {
                 using (SqlCommand cmd1 = new SqlCommand())
                 {
                     
                     cmd1.CommandText = @"SELECT top 100 RecordDateTime,C1Leak ,C2Noise , C3Spreand
               FROM   datagraph   ";


                    
                    




                     cmd1.Connection = con1;
                     using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                     {
                         da.Fill(ds, "DatosGraph");
                     }
                 }
             }
             if (ds != null)
             {
                 if (ds.Tables.Count > 0)
                 {
                     if (ds.Tables["DatosGraph"].Rows.Count > 0)
                     {
                       
                         foreach (DataRow dr in ds.Tables["DatosGraph"].Rows)
                         {
                             Debug.WriteLine((dr["RecordDateTime"].ToString()));
                             Debug.WriteLine((dr["RecordDateTime"].ToString()).Split(':')[0]);
                             Debug.WriteLine((dr["RecordDateTime"].ToString().Trim()).Substring(6, 4));
                             Debug.WriteLine((dr["RecordDateTime"].ToString().Trim()).Substring(3,2));
                             Debug.WriteLine((dr["RecordDateTime"].ToString().Trim()).Substring(0,2));
                             Debug.WriteLine((dr["RecordDateTime"].ToString()).Substring(11,2));
                             Debug.WriteLine((dr["RecordDateTime"].ToString()).Substring(14, 2));
                             string firstCharacter = (dr["RecordDateTime"].ToString().Split(':')[0].Substring(11, 2));
                             Debug.WriteLine(firstCharacter);
                             Debug.WriteLine(Convert.ToDouble(dr["C2Noise"], System.Globalization.CultureInfo.InvariantCulture));
                             if (firstCharacter.Length==1)
                             {
                                 datosplot.Add(new DataDnk
                                 {

                                     datetime = ToJsonTicks(new DateTime(Int32.Parse(dr["RecordDateTime"].ToString().Substring(6, 4)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(3, 2)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(0, 2)), Int32.Parse("0" + dr["RecordDateTime"].ToString().Substring(11, 1)), Int32.Parse(dr["RecordDateTime"].ToString().Split(':')[1]), 0)),
                                  
                                     c1pressure = Convert.ToDouble(dr["C1Leak"], System.Globalization.CultureInfo.InvariantCulture),
                                     c2flow = Convert.ToDouble(dr["C2Noise"], System.Globalization.CultureInfo.InvariantCulture),
                                     c3pressure = Convert.ToDouble(dr["C3Spreand"], System.Globalization.CultureInfo.InvariantCulture)
                                     

                                 });
                             
                             
                             
                             }
                             else{
                             
                             datosplot.Add(new DataDnk
                             {

                                 datetime = ToJsonTicks(new DateTime(Int32.Parse(dr["RecordDateTime"].ToString().Substring(6, 4)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(3, 2)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(0, 2)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(11, 2)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(14, 2)), 0)),
                                 c1pressure = Convert.ToDouble(dr["C1Leak"], System.Globalization.CultureInfo.InvariantCulture),
                                 c2flow = Convert.ToDouble(dr["C2Noise"], System.Globalization.CultureInfo.InvariantCulture),
                                 c3pressure = Convert.ToDouble(dr["C3Spreand"], System.Globalization.CultureInfo.InvariantCulture)
                              
                            
                             
                             });

                             }
                         }
                     }
                 }





             }





             return datosplot;
         }


        public JsonResult GetData()
         {
             Dictionary<int, double> data = new Dictionary<int, double>();

             data.Add(1, 2.5400F);
             data.Add(2, 3.5400F);
             data.Add(3, 4.5400F);
             data.Add(4, 3.5400F);
             data.Add(5, 2.5400F);
             data.Add(6, 1.5400F);
             return Json(DatAnalysis(), JsonRequestBehavior.AllowGet);
         }
   
        public ActionResult Index()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(DatAnalysis());
            JavaScriptSerializer serializer = new JavaScriptSerializer();




            return Json(DatAnalysis(), JsonRequestBehavior.AllowGet);
        }
   
     }

}