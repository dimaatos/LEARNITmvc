using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MVCtest.Models;
using Microsoft.AspNet.Identity;


namespace MVCtest.Controllers
{

    public class UserProfileController : Controller
    {
        private UserProfileDBContext db = new UserProfileDBContext();


        [HttpGet]
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

                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
