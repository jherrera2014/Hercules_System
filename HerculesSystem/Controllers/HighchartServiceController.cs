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

            public string loggtype { get; set; }

        }


        public virtual int AJAXRequest(int param1)
	{

        string data = Request["param1"];
        Debug.WriteLine("llego" + data);
            
            capdata = param1;
        Debug.WriteLine("llego por fin" + param1);
        Session["datodia"] = param1;
        return (param1);
	}

        public long ToJsonTicks(DateTime value)
        {
            return (value.ToUniversalTime().Ticks - ((new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks)) / 10000;
        }


  
         public List<DataDnk> DatAnalysis(int data)
         {
             datosplot = new List<DataDnk>();
             var dat = data;

             DataSet ds = new DataSet();

             SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
             

             {
                 using (SqlCommand cmd1 = new SqlCommand())
                 {

                     cmd1.CommandText = @"SELECT  RecordDateTime,C1Leak ,C2Noise , C3Spreand,Address From datagraph dat Inner Join loggers lg on lg.Id =@ID JOIN sites t  ON lg.ID = t.ID Where dat.IDLogger = lg.LoggerSMSNumber and dat.RecordDateTime
                                         BETWEEN CONVERT(datetime,('2014-10-04' + ' ' + '23:45:00')) AND CONVERT(datetime,('2014-11-04' + ' ' + '23:45:00'))  ";
                     cmd1.Parameters.Add("@ID", SqlDbType.Int);
                     cmd1.Parameters["@ID"].Value = data;
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
                       
                            string firstCharacter = (dr["RecordDateTime"].ToString().Split(':')[0].Substring(11, 2));
                                                         datosplot.Add(new DataDnk
                             {

                                 datetime = ToJsonTicks(new DateTime(Int32.Parse(dr["RecordDateTime"].ToString().Substring(6, 4)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(3, 2)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(0, 2)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(11, 2)), Int32.Parse(dr["RecordDateTime"].ToString().Substring(14, 2)), 0)),
                                 c1pressure = Convert.ToDouble(dr["C1Leak"], System.Globalization.CultureInfo.InvariantCulture),
                                 c2flow = Convert.ToDouble(dr["C2Noise"], System.Globalization.CultureInfo.InvariantCulture),
                                 c3pressure = Convert.ToDouble(dr["C3Spreand"], System.Globalization.CultureInfo.InvariantCulture),
                                  loggtype= (dr["Address"].ToString())


                             });
                         }
                     }
                 }

             }

             return datosplot;
         }


        public ActionResult Index()
        {
            string data1 =Convert.ToString(Session["id"]);
            string data = Request["param1"];
            int datval = Convert.ToInt16(data1);
            
            
            Debug.WriteLine("llego" + data1);
            string prueba = "p1";
            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(DatAnalysis(datval));
            JavaScriptSerializer serializer = new JavaScriptSerializer();




            return Json(DatAnalysis(datval), JsonRequestBehavior.AllowGet);
        }
   
     }

}