﻿using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using HerculesSystem.Models;
namespace HerculesSystem.Controllers
{
    public class ZoneSitesController : Controller
    {
        // GET: ZoneSites
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
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
            
            var ZoneLogger = new hercules_dbEntities();

            var result = from a in ZoneLogger.zones2
                         select new
                         {
                             ID = a.ID,
                             ZoneName = a.ZoneName,
                             Status = a.Status,
                             CreationDate = a.CreationDate
                         };
            

            return result;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, zone product)
        {
          //  DataClasses1DataContext dt = new DataClasses1DataContext();
            if (product != null)
              //  && ModelState.IsValid
            {

                using (var db = new hercules_dbEntities())
                {
                    var result = from u in db.zones2 where (u.ID == product.ID) select u;
                    if (result.Count() != 0)
                    {
                        var dbuser = result.First();
                        dbuser.ZoneName = product.ZoneName;
                        dbuser.Status = product.Status.Value;
                        

                        db.SaveChanges();
                    }
                } 
              

            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Create([DataSourceRequest]DataSourceRequest request, Zones product)
        {

            using (var northwind = new hercules_dbEntities())
            {
                // Create a new Product entity and set its properties from the posted ProductViewModel
                var entity = new zone
                {
                   
                    ZoneName = product.ZoneName,
                    Status = true,
                    CreationDate = DateTime.Now
                    
                };
                // Add the entity
                northwind.zones2.Add(entity);
                // Insert the entity in the database
                northwind.SaveChanges();
                // Get the ProductID generated by the database
                product.ID = entity.ID;
            }

            // Return the inserted product. The grid needs the generated ProductID. Also return any validation errors.
            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}