using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCtest.Models;

namespace MVCtest.Controllers
{
    public class ProfileController : Controller
    {

        private UserProfileDBContext db = new UserProfileDBContext();

    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserProfileModel model)
        {
            if (ModelState.IsValid)
            {

                db.UserProfiles.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
