using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.Controllers;
using ARS.Models;

namespace ARS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUS()
        {
            return View();
        }
    }
}