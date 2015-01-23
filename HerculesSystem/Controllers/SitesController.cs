using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using HerculesSystem.Models;
using System.Collections;

namespace HerculesSystem.Controllers
{
    public class SitesController : Controller
    {
        // GET: Sites
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sites d)
        {
            if (ModelState.IsValid)
            {
                using (var db = new hercules_dbEntities())
                {
                    //Get max ID table loggers
                    var crum = db.loggers.Max(sd => sd.ID);

                    int current_id = Convert.ToInt32(crum.ToString());



                    //list logger
                    string[] temporale;
                    ArrayList id_logger = new ArrayList();
                    ArrayList type_logger = new ArrayList();

                    int limit_pcp = 0 ;
                    int limit_erp =0;
                    IEnumerable source = d.SelectedLogger;
                    if (source != null)
                    {
                        foreach (var element in source)
                        {
                            temporale = element.ToString().Split(' ');
                            type_logger.Add(temporale[0].ToString());
                            id_logger.Add(temporale[1].ToString());
                            if (temporale[0].ToString() == "PCP")
                                limit_pcp = limit_pcp + 1;
                            if (temporale[0].ToString() == "ERP")
                                limit_erp = limit_erp + 1;
                        }

                        if (limit_erp > 1){
                            ViewBag.DataExists = true;
                            //ViewBag.Javascript = "<script language='javascript' type='text/javascript'>alert('Max 1 ERP by Site');</script>";
	                        return RedirectToAction("Create");
                        }
                        else if (limit_pcp > 3)
                        {
                            ViewBag.DataExists = true;
                            //ViewBag.Javascript = "<script language='javascript' type='text/javascript'>alert('Max 3 PCP by Site');</script>";
                            return RedirectToAction("Create");
                        }
                        else
                        {
                            for (int i = 0; i < id_logger.Count; i++)
                            {
                                int id =Convert.ToInt16(id_logger[i]);
                                var result = from u in db.loggers where (u.ID == id ) select u;
                                if (result.Count() != 0)
                                {
                                    var dblogger = result.First();
                                    dblogger.SiteID = current_id;
                                    db.SaveChanges();
                                }
                            }
                        }

                    }
                        

                    var entity = new sites
                    {
                        ID = current_id + 1,
                        Address = d.Address,
                        ZoneID = d.ZoneID,
                        Notes = d.Notes,
                        CompanyID = Convert.ToInt16(Session["CompanyID"].ToString()),
                        CreateDate = DateTime.Now,
                        OwnerAccount = Convert.ToInt16(Session["LogedUserID"].ToString()),
                         
                    };
                    // Add the entity
                    db.sites.Add(entity);
                    // Insert the entity in the database
                    db.SaveChanges();
                   
                    
                   
                }
                RedirectToAction("List");
                return View();
            }
            else
             
                return View();
            }

        }

    
}