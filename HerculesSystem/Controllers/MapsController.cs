using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hercules.Controllers
{
    public class GoogleMarker
    {
        public string SiteName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string InfoWindow { get; set; }
    }
 public class MapsController : Controller
    {
        // GET: Maps
     public static IList<GoogleMarker> GetMarkers()
     {
         var googleMarkers = new List<GoogleMarker>
                                    {
                                                                         
                                        
                                        
                                        new GoogleMarker
                                            {
                                                SiteName = "Limaches",
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
     
     
       
     public ActionResult GoogleMap()
        {
            return View();
        }


     public ActionResult DatosMostrar()
     {
        return View(); 
     }
     
     
     
     
     
     
     
     public ActionResult Index()
        {
            return Json(MapsController.GetMarkers(),JsonRequestBehavior.AllowGet);
        }
    }
}