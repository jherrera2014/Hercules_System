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
                         join b in db.roles
                            on a.Role equals b.RoleId


                         select new
                         {
                             a.Id,
                             Name = a.FirstName,
                             a.Username,
                             a.Email,
                             a.Mobile,
                             UserLevel = b.Description,
                             UserLevelID = b.RoleId,
                             a.LastLogin,
                             CreationDate = a.DateCreated,
                             a.Status

                         };
            result = result.OrderBy(u => u.CreationDate);
            return result;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(users us)
        {
         

            if (ModelState.IsValid)
            {
                using (var northwind = new hercules_dbEntities())
                {
                      //Get max ID table loggers
                    var crum = northwind.users.Max(sd => sd.Id);

                    int current_id = Convert.ToInt32(crum.ToString());

                    var entity = new users
                    {

                        Id = current_id+1,
                        FirstName = us.FirstName,
                        LastName = us.LastName,
                        Username = us.Username,
                        Password = us.Password,
                        Email = us.Email,
                        Mobile = us.Mobile,
                        DateCreated = DateTime.Now,
                        Role = us.Role,
                        RecieveNotifications = us.RecieveNotifications,
                        Status = true,
                        CompanyID = Convert.ToInt16(Session["CompanyID"].ToString())

                    };
                    // Add the entity
                    northwind.users.Add(entity);
                    // Insert the entity in the database
                    northwind.SaveChanges();
                    return RedirectToAction("List");
                }
            }
             else{
               
                return View(us);
            }

           
        }

        public ActionResult Edit(int Id)
        {
          
           hercules_dbEntities db = new hercules_dbEntities();
             
            return View("Edit", db.users.Find(Id));
          
            
        }
        [HttpPost]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, users us)
        {

            if (ModelState.IsValid)
            {
                using (var db = new hercules_dbEntities())
                {
                    var result = from u in db.users where (u.Id == us.Id) select u;
                    if (result.Count() != 0)
                    {
                        var dbuser = result.First();
                        
                        dbuser.FirstName = us.FirstName;
                        dbuser.LastName = us.LastName;
                        dbuser.Username = us.Username;
                        dbuser.Password = us.Password;
                        dbuser.Email = us.Email;
                        dbuser.Mobile = us.Mobile;
                        dbuser.Role = us.Role;
                        dbuser.RecieveNotifications = us.RecieveNotifications;
                        dbuser.Status = us.Status;


                        db.SaveChanges();
                    }
                }
            }
            
           
            return RedirectToAction("List");
        }
    }
}