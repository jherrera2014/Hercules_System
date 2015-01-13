using HerculesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hercules.Controllers
{
    public class HelperController : Controller
    {
        // GET: GraphStock
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetZone()
        {

            var zone = new hercules_dbEntities();

            return Json(zone.zones2.Select(c => new { ID = c.ID, ZoneName = c.ZoneName }), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetLogger(int? ZoneDropDownList)
        {

            var db = new hercules_dbEntities();

            var jointable = from a in db.loggers

                            join b in db.siteloggersassociations
                                on a.ID  equals b.LoggerID
                            join c in db.sites
                                on b.SiteID equals c.ID
                            select new
                            {
                                ID = a.ID,
                                IDZone = c.ZoneID,
                                LoggerName = c.Address
                            };

            if (ZoneDropDownList != null)
            {
                jointable = jointable.Where(o => o.IDZone == ZoneDropDownList);
                return Json(jointable.Select(o => new { LoggerID = o.ID, LoggerName = o.LoggerName }), JsonRequestBehavior.AllowGet);
            }

            else

                return Json(null);
        }

        public JsonResult GetUser()
        {

            var db = new hercules_dbEntities();

            var user_result = from a in db.users
                              join b in db.company
                                 on a.CompanyID equals b.ID

                              select new
                              {
                                  ID = a.Id,
                                  UserName = a.FirstName + " " + a.LastName,
                                  CompanyID = a.CompanyID

                              };
            //user_result = user_result.Where(o => o.CompanyID.ToString() == Session["CompanyID"].ToString());
            return Json(user_result.Select(o => new { ID = o.ID, UserName = o.UserName }), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetSites()
        {

            //string company_id = Session["CompanyID"].ToString();
            var db = new hercules_dbEntities();

            var user_result = from a in db.sites
                              join b in db.company
                              on a.CompanyID equals b.ID
                              
                              select new
                              {
                                  ID = a.ID,
                                  Adress = a.Address,
                                  CompanyID = a.CompanyID
                              };
            
            //o.CompanyID.ToString() == company_id && 
            
            return Json(user_result.Select(o => new { o.ID, o.Adress }), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetOnlyLoggers()
        {

            //string company_id = Session["CompanyID"].ToString();
            var db = new hercules_dbEntities();
            string company_id = Session["CompanyID"].ToString();
            var user_result = from a in db.loggers
                             
                              select new
                              {
                                  ID = a.ID,
                                  LoggerSMS = a.LoggerSMSNumber,
                                  CompanyID = a.CompanyID
                              };
            user_result = user_result.Where(o => o.CompanyID.ToString() == company_id);

            return Json(user_result.Select(o => new { o.ID, o.LoggerSMS }), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetLevel()
        {
            var db = new hercules_dbEntities();

            var rol_result = from a in db.roles

                              select new
                              {
                                  a.RoleId,
                                  a.Description
                              };

            return Json(rol_result.Select(o => new { o.RoleId, o.Description }), JsonRequestBehavior.AllowGet);
        }
    }


}