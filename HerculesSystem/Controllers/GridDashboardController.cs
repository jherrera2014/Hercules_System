using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hercules.Controllers
{
    public class GridDashboardController : Controller
    {
        // GET: GridDashboard
        public ActionResult Index()
        {
            return View();
        }

        public class DataGridView
        {
            public int loggerid { get; set; }
            public string alertType { get; set; }
            public DateTime alertDate { get; set; }
            public string zone { get; set; }
            public string subZone { get; set; }
            public string personResponsable { get; set; }
        }


    }
}