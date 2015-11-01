using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MightBeFinal.Models;

namespace MightBeFinal.Controllers
{
    public class CourseController : Controller
    {
        ApplicContext db = new ApplicContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseName,CourseAbout,On air since, PhotoPicUrl")]Course course)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(course);
                    db.SaveChanges();

                    return RedirectToAction("Create");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            
            return View(course);
        }
    }
}