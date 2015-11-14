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
    public class CourseController : Controller
    {
        private ApContext db = new ApContext();

        public ActionResult CoursePage()
        {
            return View();
        }

        


        public ActionResult ByName(string searchString)
        {
            //var courses = db.Courses.Include(c => c.Category).Include(c => c.Photo).Include(c => c.Teacher);

            var courserus = from s in db.Courses.OrderBy(q => q.CourseName)
                            select s;

            int total = db.Courses.Count();


            if (!String.IsNullOrEmpty(searchString))
            {
                courserus = courserus.Where(s => s.CourseName.Contains(searchString));
               
            }

            ViewBag.Message = db.Courses.Count();
            ViewBag.Categories = db.Categories.Count();
            ViewBag.Teachers = db.Teachers.Count();
            return View(courserus.OrderBy(q => q.CourseName).ToList());
        }

        [Authorize]
        public ActionResult AdminByName(string searchString)
        {
            //var courses = db.Courses.Include(c => c.Category).Include(c => c.Photo).Include(c => c.Teacher);

            var courserus = from s in db.Courses.OrderBy(q => q.CourseName)
                            select s;

            int total = db.Courses.Count();


            if (!String.IsNullOrEmpty(searchString))
            {
                courserus = courserus.Where(s => s.CourseName.Contains(searchString));

            }

            ViewBag.Subscribers = db.Subscribers.Count();
            ViewBag.Subscriptions = db.Subscriptions.Count();
            ViewBag.Courses = db.Courses.Count();
            ViewBag.Categories = db.Categories.Count();
            ViewBag.Teachers = db.Teachers.Count();

            return View(courserus.OrderBy(q => q.CourseName).ToList());
        }



        public ActionResult ByCategory(int? SelectedCategory)
        {
            var categories = db.Categories.OrderBy(q => q.CategoryName).ToList();


            ViewBag.SelectedCategory = new SelectList(categories, "CategoryID", "CategoryName", SelectedCategory);
            int CategoryID = SelectedCategory.GetValueOrDefault();

            IQueryable<Course> courses = db.Courses
                .Where(c => !SelectedCategory.HasValue || c.CategoryId == CategoryID)
                .OrderBy(d => d.CourseName)
                .Include(d => d.Category);
            var sql = courses.ToString();


            return View(courses.ToList());
        }

        [Authorize]
        public ActionResult AdminByTeacher(int? SelectedTeacher)
        {
            var teachers = db.Teachers.OrderBy(q => q.TeacherName).ToList();


            ViewBag.SelectedTeacher = new SelectList(teachers, "TeacherID", "TeacherName", SelectedTeacher);
            int TeacherID = SelectedTeacher.GetValueOrDefault();

            IQueryable<Course> courses = db.Courses
                .Where(c => !SelectedTeacher.HasValue || c.TeacherId == TeacherID)
                .OrderBy(d => d.CourseName)
                .Include(d => d.Teacher);
            var sql = courses.ToString();


            ViewBag.Subscribers = db.Subscribers.Count();
            ViewBag.Subscriptions = db.Subscriptions.Count();
            ViewBag.Courses = db.Courses.Count();
            ViewBag.Categories = db.Categories.Count();
            ViewBag.Teachers = db.Teachers.Count();

            return View(courses.ToList());
        }


        [Authorize]
        public ActionResult AdminByCategory(int? SelectedCategory)
        {
            var categories = db.Categories.OrderBy(q => q.CategoryName).ToList();

            ViewBag.SelectedCategory = new SelectList(categories, "CategoryID", "CategoryName", SelectedCategory);
            int CategoryID = SelectedCategory.GetValueOrDefault();

            IQueryable<Course> courses = db.Courses
                .Where(c => !SelectedCategory.HasValue || c.CategoryId == CategoryID)
                .OrderBy(d => d.CourseName)
                .Include(d => d.Category);
            var sql = courses.ToString();

            ViewBag.Subscribers = db.Subscribers.Count();
            ViewBag.Subscriptions = db.Subscriptions.Count();
            ViewBag.Courses = db.Courses.Count();
            ViewBag.Categories = db.Categories.Count();
            ViewBag.Teachers = db.Teachers.Count();

            return View(courses.ToList());
        }




        // GET: Course/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.PhotoId = new SelectList(db.Photos, "PhotoID", "PhotoName");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "CourseID,CourseName,StartDate,CourseAbout,CategoryId,TeacherId,PhotoId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName", course.CategoryId);
            ViewBag.PhotoId = new SelectList(db.Photos, "PhotoID", "PhotoName", course.PhotoId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherID", "TeacherName", course.TeacherId);
            return View(course);
        }

        // GET: Course/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName", course.CategoryId);
            ViewBag.PhotoId = new SelectList(db.Photos, "PhotoID", "PhotoName", course.PhotoId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherID", "TeacherName", course.TeacherId);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,StartDate,CourseAbout,CategoryId,TeacherId,PhotoId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "CategoryName", course.CategoryId);
            ViewBag.PhotoId = new SelectList(db.Photos, "PhotoID", "PhotoName", course.PhotoId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherID", "TeacherName", course.TeacherId);
            return View(course);
        }

        // GET: Course/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
