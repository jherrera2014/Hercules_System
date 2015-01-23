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
    public class AssociationsController : Controller
    {
        // GET: Associations
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
            var db = new hercules_dbEntities();
            
            var result = from a in db.loggers
                         join b in db.sites
                             on a.SiteID equals b.ID
                         join c in db.zones2
                             on b.ZoneID equals c.ID
                         join d in db.users
                              on a.OwnerAccount equals d.Id
                         select new
                         {
                             a.ID,
                             LoggerSMSNumber = a.LoggerSMSNumber,
                             BatteryLevel = a.BatteryLevel,
                             LastCallIn = a.LastCallIn,
                             Adress = a.Adress,
                             LoggerSerialNumber = a.LoggerSerialNumber,
                             LoggerType = a.LoggerType,
                             SignalLevel = a.SignalLevel,
                             Owner = d.FirstName + " " + d.LastName,
                             OwnerID = d.Id,
                             a.CreationDate,
                             SiteID = a.SiteID,
                             SiteName = b.Address,
                             ZoneID = c.ID,
                             ZoneName = c.ZoneName
                         };
           
            result = result.OrderBy(u => u.CreationDate);
            return result;
        }
    }
}