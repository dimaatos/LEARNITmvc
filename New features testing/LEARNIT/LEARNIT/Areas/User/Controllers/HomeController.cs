﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEARNIT.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        // GET: User/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}