using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MVCtest.Models;


namespace MVCtest.Controllers
{

    public class UserProfileController : Controller
    {
        [HttpPost]
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {
                var db = new UserProfileDataContext()
            }
        }

    }
}
