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
    public class UsersController : Controller
    {
        // GET: Users
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

            var result = from a in db.users
                         select new
                         {
                             a.Id,
                             Name = a.FirstName,
                             a.Username,
                             a.Email,
                             a.Mobile,
                             UserLevel = a.Role,
                             a.LastLogin,
                             CreationDate = a.DateCreated,
                             Owner = a.ParentAccount

                         };
            result = result.OrderBy(u => u.CreationDate);
            return result;
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}