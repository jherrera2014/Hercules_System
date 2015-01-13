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
    public class SitesController : Controller
    {
        // GET: Sites
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
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
            var db = new hercules_dbEntities();
           
            var result = from a in db.sites
                         join b in db.zones2
                             on new { emp = a.ZoneID } equals new { emp = b.ID }
                         select new
                         {
                              a.ID,
                              Adress = a.Address,
                              CreationDate = a.CreateDate,
                              ZoneID = b.ID,
                              ZoneName = b.ZoneName
                         };
            //result = result.Where(u => u. == true);
            result = result.OrderBy(u => u.CreationDate);
            return result;
        }
    }
}