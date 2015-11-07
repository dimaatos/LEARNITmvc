using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LEARNIT.Models;

namespace LEARNIT.Controllers
{
    public class HomeController : Controller
    {
       
        private ApContext db = new ApContext();

        public ActionResult Index(string searchString)
        {
            var courses = db.Courses.Include(c => c.Category).Include(c => c.Photo).Include(c => c.Teacher);

            var courserus = from s in db.Courses
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                courserus = courserus.Where(s => s.CourseName.Contains(searchString));
            }

            ViewBag.Message = db.Courses.Count();
            ViewBag.Categories = db.Categories.Count();
            ViewBag.Teachers = db.Teachers.Count();
            return View(courserus.ToList());
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}

      
    }
}