using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class BrowseCatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult HunanitiesAndFineArt()
        {
            return View();
        }

        public ActionResult Business()
        {
            return View();
        }

        public ActionResult ComputerScience()
        {
             return View();
        }

        public ActionResult MedicineBiology()
        {
            return View();
        }

        public ActionResult MathsAndlogic()
        {
            return View();
        }

        public ActionResult PhysicsAndEngeneering()
        {
            return View();
        }

        public ActionResult SocialScience()
        {
            return View();
        }

    }
}