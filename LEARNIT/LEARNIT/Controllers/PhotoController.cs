using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LEARNIT.Models;

namespace PhotosUpload.Controllers
{
    public class PhotoController : Controller
    {
        private ApContext db = new ApContext();

        // GET: /Photo/
        public ActionResult Index()
        {

            return View(db.Photos.ToList());
        }

        // GET: /Photo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: /Photo/Upload
        public ActionResult Upload()
        {
            return View();
        }

        // POST: /Photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadImage()
        {
            if (Request.Files["file"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
                string filename = System.IO.Path.GetFileNameWithoutExtension(Request.Files["file"].FileName);
                string FileNameOnServer = Photo.GenerateRandomString() + extension;

                string path = string.Format("{0}/{1}", Server.MapPath("~/Upload/Photo"), FileNameOnServer);

                while (System.IO.File.Exists(path))
                {
                    // if a file with this name already exists,
                    FileNameOnServer = Photo.GenerateRandomString() + extension;
                    path = string.Format("{0}/{1}", Server.MapPath("~/Upload/Photo"), FileNameOnServer);
                }

                db.Photos.Add(new Photo(filename, FileNameOnServer));
                db.SaveChanges();

                Request.Files["file"].SaveAs(path);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: /Photo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: /Photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string PhotoName)
        {
            Photo photo = db.Photos.Find(id);
            photo.PhotoName = PhotoName;
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: /Photo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: /Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
