using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Models;
using SMS.ViewModels;

namespace SMS.Controllers
{
    public class StudentAttendenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentAttendence
        public ActionResult Index()
        {
            var studentAttendences = db.StudentAttendences.Include(s => s.ClassOrYears);
            return View(studentAttendences.ToList());
        }

        // GET: StudentAttendence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendence);
        }

        // GET: StudentAttendence/Create
        public ActionResult Create()
        {
            ViewStudentAttendence objViewStudentAttendence = new ViewStudentAttendence();

            objViewStudentAttendence.Class = new SelectList(db.ClassOrYears, "Code", "Name");

            var students = db.StudentAttendences.Where(x => x.DateTime.Year == DateTime.Now.Year &&

                                            x.DateTime.Month == DateTime.Now.Month && x.DateTime.Day == DateTime.Now.Day).ToList();
            //  ViewBag.StudentList = students; change here....
            //  StudentAttendenceList Declare ViewStudentAttendence(View Models) 
            objViewStudentAttendence.StudentAttendenceList = students;




            return View(objViewStudentAttendence);
        }

        // POST: StudentAttendence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentAttendence")]  ViewStudentAttendence objViewStudentAttendence)
        {
            if (ModelState.IsValid)
            {
                if (objViewStudentAttendence.StudentAttendence.TotalPresentStudent > objViewStudentAttendence.StudentAttendence.TotalStudent)
                {
                   
                    TempData["Message"] = "Pls Enter Total valid Present Student!!";
                    return RedirectToAction("Create");
                }
                if (objViewStudentAttendence.StudentAttendence.PresentFemaleStudent > objViewStudentAttendence.StudentAttendence.FemaleStudentNo)
                {
                    TempData["Message"] = "Pls Enter Valid Present Female Student";
                    return RedirectToAction("Create");
                }
                db.StudentAttendences.Add(objViewStudentAttendence.StudentAttendence);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            var students = db.StudentAttendences.Where(x => x.DateTime.Year == DateTime.Now.Year &&

                                          x.DateTime.Month == DateTime.Now.Month && x.DateTime.Day == DateTime.Now.Day).ToList();


            //  ViewBag.StudentList = students; change here
            objViewStudentAttendence.StudentAttendenceList = students;




            objViewStudentAttendence.Class = new SelectList(db.ClassOrYears, "Code", "Name", objViewStudentAttendence.StudentAttendence);
            return View(objViewStudentAttendence);
        }

        // GET: StudentAttendence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name", studentAttendence.ClassOrYearId);
            return View(studentAttendence);
        }

        // POST: StudentAttendence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassOrYearId,TotalStudent,FemaleStudentNo,TotalPresentStudent,PresentFemaleStudent,DateTime")] StudentAttendence studentAttendence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassOrYearId = new SelectList(db.ClassOrYears, "Code", "Name", studentAttendence.ClassOrYearId);
            return View(studentAttendence);
        }

        // GET: StudentAttendence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            if (studentAttendence == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendence);
        }

        // POST: StudentAttendence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendence studentAttendence = db.StudentAttendences.Find(id);
            db.StudentAttendences.Remove(studentAttendence);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult GetTotalStudent(string classCode)
        {
            if (classCode != null)
            {
                var totaStudentCount = db.StudentAccounts.Where(c => c.ClassOrYearId == classCode).Count();
                var femaleStudentCount = db.StudentAccounts.Where(c => c.ClassOrYearId == classCode && c.Gender == "Female").Count();

                return Json(new { result = "success", totaStudentCount = totaStudentCount, femaleStudentCount = femaleStudentCount }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);

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
