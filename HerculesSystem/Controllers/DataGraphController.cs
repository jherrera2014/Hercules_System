

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

using  System.Runtime.InteropServices;




using Hercules.Models;

namespace Hercules.Controllers
{
    
    public class DataGraphController : Controller
    {

       
        private class State
        {
            public CultureInfo Result { get; set; }
        }


     
        
        
        // GET: DataGraph
        DataDnk[] allRecords = null;
        SqlDataReader dr;

        public static string[] datafech;
        public static int[] c1press;
        DateTime backupdate;
        static System.Globalization.NumberFormatInfo ni = null;
        string dat;
        double resultado;
        double balance;
        CultureInfo myCulture;
        ArrayList arrayList;
        ArrayList arrayListfech;
        string[] timestamp;
         System.Globalization.CultureInfo myInfo;
         Decimal d;
         String datos;
         object[] values;
         List<DataDnk> datosplot;
         string[] fechas ;
         Double[] c1pressu ;
         public List<DataDnk> DatAnalysis()
         {
             datosplot = new List<DataDnk>();
           

             DataSet ds = new DataSet();
             SqlConnection con1 = new SqlConnection("Data Source=158.85.25.234;Database=hercules_db;User ID=jonathan-desarrollo;Password=johnnydesarrollo;Trusted_Connection=false; ");
             {
                 using (SqlCommand cmd1 = new SqlCommand())
                 {
                     cmd1.CommandText = @"SELECT top 10 RecordDateTime,C1Leak ,C2Noise,C3Spreand
               FROM   datagraph";
                     cmd1.Connection = con1;
                     using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                     {
                         da.Fill(ds, "DatosGraph");
                     }
                 }
             }
             if (ds != null )
             {
                 if (ds.Tables.Count > 0)
                 {
                     if (ds.Tables["DatosGraph"].Rows.Count > 0  )
                     {
                         arrayListfech = new ArrayList();
                         arrayList = new ArrayList();
                         foreach (DataRow dr in ds.Tables["DatosGraph"].Rows)
                         {
                             datosplot.Add(new DataDnk
                             {
                                 datetime = dr["RecordDateTime"].ToString(),
                                 c1pressure = Convert.ToDouble(dr["C2Noise"])
                             });
                             arrayList.Add(dr["C1Leak"]);
                             arrayListfech.Add(dr["RecordDateTime"]);
                         
                         }
                     }
                 }

              
                
             
             
             }





             return datosplot;
         }

        public ActionResult Index()
        {
            //Create Series 1

          
            DataSet ds = new DataSet();


            var  fech = DatAnalysis().Select(i => i.datetime).ToArray() ;
            c1pressu = DatAnalysis().Select(i => i.c1pressure).ToArray();
            var yDataSalary = (DatAnalysis().Select(i => new[] { i.c1pressure })).ToArray();
          
          //    Decimal d = Decimal.Parse(tmp, myInfo); //123.45

            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
                //rodzaj wykresu - liniowy
 .InitChart(new Chart {
     
     
     DefaultSeriesType = ChartTypes.Line,

     Type = ChartTypes.Line,
                MarginRight=  130,
                 MarginBottom = 70
 
 
 
 })
                //tytuł wykresu
 .SetTitle(new Title { Text = "Zarobki w miesiącu" })
 .SetSubtitle(new Subtitle { Text = "Programista" })
                //wartosci na osi X
 .SetXAxis(new XAxis {

                    Type = AxisTypes.Category,
       
                    Title = new XAxisTitle { Text = "Altitude" },
            
                 
                    Min = 0,
                    Max = 20,
                    Categories= fech
     
     
    })
                //wartosci na osi Y

           
                
                
                
                .SetYAxis(new YAxis {
     
    Title = new YAxisTitle {

        Text = "Wielkość zarobku"


    }, 
         Min = 0,
        Max = 200

      
 
 
 
 })






 .SetTooltip(new Tooltip
 {
     Enabled = true,
     Formatter = @"function() { return '<b>'+ this.series.name +'</b><br/>'+ this.x +': '+ this.y; }"
 })
 .SetPlotOptions(new PlotOptions
 {
     Line = new PlotOptionsLine
     {
         DataLabels = new PlotOptionsLineDataLabels
         {
             Enabled = true
         },
         EnableMouseTracking = false
     }
 })
                //wczywtywanie osi Y
 .SetSeries(new[] 
{
new Series { Data = new Data( arrayList.ToArray() )},
});
            return View(chart);



        }

       
        
       
        
        
        
        // GET: DataGraph/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DataGraph/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataGraph/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DataGraph/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataGraph/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DataGraph/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataGraph/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    
    
   
    
    
    
    
    
    
    
    }
}
