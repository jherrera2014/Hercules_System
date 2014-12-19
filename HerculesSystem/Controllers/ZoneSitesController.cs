using Kendo.Mvc.UI;
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
            //DataClasses1DataContext db = new DataClasses1DataContext();
            var ZoneLogger = new ZoneLogger();

            var result = from a in ZoneLogger.zone
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
            DataClasses1DataContext dt = new DataClasses1DataContext();
            if (product != null)
              //  && ModelState.IsValid
            {

                using (ZoneLogger db = new ZoneLogger())
                {
                    var result = from u in db.zone where (u.ID == product.ID) select u;
                    if (result.Count() != 0)
                    {
                        var dbuser = result.First();
                        dbuser.ZoneName = product.ZoneName;
                       // DateTime drt = Convert.ToDateTime(product.CreationDate);
                       // dbuser.CreationDate = product.CreationDate.Value;
                        dbuser.Status = Convert.ToBoolean(product.Status);
                        

                        db.SaveChanges();
                    }
                } 
              

            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}