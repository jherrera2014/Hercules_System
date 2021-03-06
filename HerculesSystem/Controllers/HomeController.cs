﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hercules.Models;
using System.Web.Security;
using HerculesSystem;
using HerculesSystem.Models;

namespace Hercules.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        
        public ActionResult Login()
        {
            Session.Clear();

            FormsAuthentication.SetAuthCookie(null,false);
            Session.Abandon();
            //HttpCookie cookie = Request.Cookies["aLog"];
            //cookie.Expires = DateTime.Now.AddYears(1);
            //Response.AppendCookie(cookie);
            //Response.Cookies.Clear();
            //FormsAuthentication.RedirectToLoginPage();
            FormsAuthentication.SignOut();
            
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



       [HttpPost]
 
    [AllowAnonymous]
    public ActionResult Login(user u)
    {
        // this action is for handle post (login)
        if (ModelState.IsValid) // this is check validity
        {
            using (var mc = new hercules_dbEntities())
            {

                var vc = mc.company.Where(c => c.CompanyName.Equals(u.Email)).FirstOrDefault();
                if (vc != null)
                {
                    Session["CompanyID"] = vc.ID.ToString();
                    Session["CompanyName"] = vc.CompanyName.ToString();
                }
                else
                {
                    Session["CompanyID"] = null;
                    Session["CompanyName"] = null;
                }

            }



            using (hercules_dbEntities dc = new hercules_dbEntities())
            {
                if (Session["CompanyID"] != null) { 
                    Int32 value_company_id = Convert.ToInt32(Session["CompanyID"].ToString());
                    var v = dc.users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password) && a.CompanyID.Equals(value_company_id)).FirstOrDefault();
                    if (v != null)
                    {
                        //Update the last connection by user
                        var update = from fu in dc.users where (fu.Id == v.Id) select fu;
                        if (update.Count() != 0) { 
                        var dbuser = update.First();
                        dbuser.LastLogin = DateTime.Now;
                         
                         dc.SaveChanges();
                         }
                        
                        Session["LogedUserID"] = v.Id.ToString();
                        Session["LogedUserFullname"] = v.Username.ToString();
                        FormsAuthentication.SetAuthCookie(v.Username.ToString(), true);
                        return RedirectToAction("List","Dashboard");
                    }else
                        ModelState.AddModelError("", Resources.ResourceLanguage.UserInvalid);
                }else
                    ModelState.AddModelError("", Resources.ResourceLanguage.UserInvalid);
            }
        }
        return View(u);
    }


       public ActionResult AfterLogin()
       {
           if (Session["LogedUserID"] != null)
           {
               return View();
           }
           else
           {
               return RedirectToAction("Index");
           }
       }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "jherrera@dnkwater.com.";

            return View();
        }
    }
}