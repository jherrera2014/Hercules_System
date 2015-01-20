using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hercules
{
    public class RouteConfig
    {


      



        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "LogOut", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                   name: "Graficos",
                   url: "{HighchartService}/{index}/{id}",
                   defaults: new {  action = "Index", id = UrlParameter.Optional }

               );
            routes.MapRoute(
                      name: "Datos1",
                      url: "{Grafico}/{index}/{id}",
                      defaults: new { action = "Index", id = UrlParameter.Optional }
                  );

            routes.MapRoute(
                     name: "Dashboard",
                     url: "{Dashboard}/{index}/{id}",
                     defaults: new { action = "List", id = UrlParameter.Optional }
                 );
        

            routes.MapRoute(
                          name: "Mapa",
                          url: "{Maps}/{GetMarkersAsync}/{id}",
                          defaults: new { action = "GetMarkersAsync", id = UrlParameter.Optional }
                      );

            routes.MapRoute(
                         name: "logger",
                         url: "{Logger}/{Index}/{id}",
                         defaults: new { action = "Index", id = UrlParameter.Optional }
                     );
            routes.MapRoute(
                         name: "databot",
                         url: "{Logger}/{ DetailButton}/{id}",
                         defaults: new { action = " DetailButton", id = UrlParameter.Optional }
                     );
           
        
     
        }

       
    
    
    
    }






}
