using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.Models;
using ARS.Controllers;

namespace ARS.Controllers
{
    public class AdminController : Controller
    {
        ContextCS c = new ContextCS();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        public ActionResult AdminLogin()
        {
            if (Session["admin"]!=null)
            {
                return RedirectToAction("Deshbord");
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminLogin l)
        {
            var x = c.AdminLogins.Where(a => a.AdminName == l.AdminName && a.AdminPassword == l.AdminPassword).FirstOrDefault();
            if (x!=null)
            {
                Session["admin"] = l.AdminName;
                return RedirectToAction("Deshbord");
            }
            else
            {
                ViewBag.login = "Con not redirect to Dashbord you are entered wrong password";
            }
            return View();
        }
        public ActionResult Deshbord()
        {
            return View();
        }
    }
}