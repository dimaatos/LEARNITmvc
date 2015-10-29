using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCtest.Models;

namespace MVCtest.Controllers
{
    public class UserController : Controller
    {
        private readonly LearnItDB _db = new LearnItDB();

        [HttpGet]
        public ActionResult Register()
        {
            UserTable newUser = new UserTable();

            return View(NewUser);
        }

        [HttpPost]
        public ActionResult Register(UserTable model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }            

            _db.UserTables.Add(model);
            _db.SaveChanges();            

            return RedirectToAction("Index", "Home");
        }
    }
}