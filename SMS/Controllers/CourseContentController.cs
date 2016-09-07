using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Controllers
{
    public class CourseContentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseContent
        public ActionResult Index()
        {
            return View(db.CourseContents.ToList());
        }

        // GET: CourseContent/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseContent courseContent = db.CourseContents.Find(id);
            if (courseContent == null)
            {
                return HttpNotFound();
            }
            return View(courseContent);
        }

        // GET: CourseContent/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassOrYears, "Code", "Name");
            return View();
        }

        // POST: CourseContent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,CourseLevel,CourseType,ClassId,CourseCatagory,Group")] CourseContent courseContent)
        {
            if (ModelState.IsValid)
            {
                db.CourseContents.Add(courseContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassOrYears, "Code", "Name");
            return View(courseContent);
        }

        // GET: CourseContent/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseContent courseContent = db.CourseContents.Find(id);
            if (courseContent == null)
            {
                return HttpNotFound();
            }
            return View(courseContent);
        }

        // POST: CourseContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,CourseLevel,CourseType,ClassId,CourseCatagory,Group")] CourseContent courseContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseContent);
        }

        // GET: CourseContent/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseContent courseContent = db.CourseContents.Find(id);
            if (courseContent == null)
            {
                return HttpNotFound();
            }
            return View(courseContent);
        }

        // POST: CourseContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CourseContent courseContent = db.CourseContents.Find(id);
            db.CourseContents.Remove(courseContent);
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
