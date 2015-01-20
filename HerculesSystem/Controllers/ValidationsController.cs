using HerculesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerculesSystem.Controllers
{
    public class ValidationsController : Controller
    {
        // GET: Validations
        public ActionResult Index()
        {
            return View();
        }

        //user validation email
        public ActionResult EmailValidation(string email, string InitialEmail)
        {
            if(email == InitialEmail)
                return Json(true, JsonRequestBehavior.AllowGet); 

            using (hercules_dbEntities db = new hercules_dbEntities())
            {
                try
                {
                    var tag = db.users.Single(m => m.Email == email);
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
        }

        //user - validation login
        public ActionResult UserValidation(string user)
        {
            using (hercules_dbEntities db = new hercules_dbEntities())
            {
                try
                {
                    var tag = db.users.Single(m => m.Username == user);
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
        }

        //logger - sms
        public ActionResult LoggerValidation(string LoggerSMSNumber, string initialSMS)
        {
            if (LoggerSMSNumber == initialSMS)
                return Json(true, JsonRequestBehavior.AllowGet); 

            using (hercules_dbEntities db = new hercules_dbEntities())
            {
                try
                {
                    var tag = db.loggers.Single(m => m.LoggerSMSNumber == LoggerSMSNumber);
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
  
}