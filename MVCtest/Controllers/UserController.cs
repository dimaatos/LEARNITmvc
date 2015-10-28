using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class UserController : Controller
    {
       UsersEntities db = new UsersEntities();


        public ActionResult Register()
        {
            var NewUser = new UserTable();
            return View(NewUser);
        }



        public ActionResult Register(UserTable model)
        {

            if (ModelState.IsValid)
            {
                UserTable user = new UserTable();

                user.loginName = model.loginName;
                user.userEmail = model.userEmail;
                user.userPassword = model.userPassword;

                db.UserTables.Add(model);

                return View(model);
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}