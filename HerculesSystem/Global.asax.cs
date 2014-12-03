using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hercules
{
    public class MvcApplication : System.Web.HttpApplication
    {



        


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Grafico",                                              // Route name
                "{HighchartService}/{action}/{id}",                           // URL with parameters
                new {  action = "Index", id = "" }  // Parameter defaults
            );


            routes.MapRoute(
                   "Datos",                                              // Route name
                   "{Grafico}/{action}/{id}",                           // URL with parameters
                   new { action = "Index", id = "" } 
                   
                   // Parameter defaults
               );

            routes.MapRoute(
                     "Map",                                              // Route name
                     "{Maps}/{GetMarkersAsync}/{id}",                           // URL with parameters
                     new { action = "GetMarkersAsync", id = "" }

                     // Parameter defaults
                 );




        
        }

       
        
        
        
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterRoutes(RouteTable.Routes);
        
        
      
        
        
        
        
        
        
        
        }



      




    
    }



        





}
