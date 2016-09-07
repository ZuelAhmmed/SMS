using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Models;
using SMS.ViewModels;

namespace SMS.Controllers
{
    public class CourseGroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseGroup
        public ActionResult Index()
        {
            var courseGroups = db.CourseGroups.Include(c => c.ClassOrYears).Include(c => c.CourseContents).Include(c => c.TeacherInfo);
            return View(courseGroups.ToList());
        }

        // GET: CourseGroup/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseGroup courseGroup = db.CourseGroups.Find(id);
            if (courseGroup == null)
            {
                return HttpNotFound();
            }
            return View(courseGroup);
        }

        // GET: CourseGroup/Create
        public ActionResult Create()
        {
            ViewCourseGroup objViewCourseGroup = new ViewCourseGroup();
            List<ViewCourseGroupSchedule> objViewCourseGroupSchedule = new List<ViewCourseGroupSchedule>();
            var data = (from s in db.ScheduleInformations
                        select new
                        {
                            ScheduleId = s.ShScheduleId,
                            roomNo = s.RoomInformation.RmRoomNo,
                            SHDay = s.ShDay,
                            FromTime = s.ShFromTime,
                            ToTime = s.ShToTime
                        });
            foreach (var item in data)
            {
                var fromTime = item.FromTime.Value.ToString("h:mm tt", CultureInfo.CreateSpecificCulture("en-BD"));
                var toTime = item.ToTime.Value.ToString("h:mm tt", CultureInfo.CreateSpecificCulture("en-BD"));

                var schedule = item.roomNo + " " + item.SHDay + " " + fromTime + "-" + toTime;
                objViewCourseGroupSchedule.Add(new ViewCourseGroupSchedule());
                objViewCourseGroupSchedule[objViewCourseGroupSchedule.Count - 1].ScheduleId = item.ScheduleId;
                objViewCourseGroupSchedule[objViewCourseGroupSchedule.Count - 1].Schedule = schedule;
            }
            objViewCourseGroup.CourseGroupScheduleList = objViewCourseGroupSchedule;
            objViewCourseGroup.ScheduleIno = new SelectList(objViewCourseGroupSchedule, "ScheduleId", "Schedule");
            objViewCourseGroup.ClassId = new SelectList(db.ClassOrYears, "Code", "Name");
            objViewCourseGroup.CourseId = new SelectList(db.CourseContents.Where(s => s.ClassId == "").ToList(), "CourseId", "CourseName");
            objViewCourseGroup.TeacherId = new SelectList(db.EmployeeAccounts, "AccountId", "EmployeeCatagoryId");
           // objViewCourseGroup.ScheduleInformationT = db.ScheduleInformations.ToList();
            return View(objViewCourseGroup);
           
        }

        // POST: CourseGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,CourseId,GroupId,TeacherId,TeacherId1,TeacherId2,Capacity,StudentCount,ClassId,SectionGroup,DayTimeSlot,Sex")] CourseGroup courseGroup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CourseGroups.Add(courseGroup);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ClassId = new SelectList(db.ClassOrYears, "Code", "Name", courseGroup.ClassId);
        //    ViewBag.CourseId = new SelectList(db.CourseContents, "CourseId", "CourseName", courseGroup.CourseId);
        //    ViewBag.TeacherId = new SelectList(db.EmployeeAccounts, "AccountId", "EmployeeCatagoryId", courseGroup.TeacherId);
        //    return View(courseGroup);
        //}




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseGroup")] ViewCourseGroup viewCoursegroup)
        {
            if (ModelState.IsValid)
            {
                var data = db.ScheduleInformations.Find(Convert.ToInt64(viewCoursegroup.CourseGroup.DayTimeSlot));
                if (data.ShCourse != null)
                {
                    TempData["Message"] = " Schedule Assign ";
                    return RedirectToAction("Index");
                }

                db.CourseGroups.Add(viewCoursegroup.CourseGroup);
                db.SaveChanges();



                data.ShCourse = viewCoursegroup.CourseGroup.CourseId;
                data.ShSection = viewCoursegroup.CourseGroup.GroupId;

                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

                //db.CourseGroups.Add(courseGroup);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            viewCoursegroup.ClassId = new SelectList(db.ClassOrYears, "Code", "Name", viewCoursegroup.ClassId);
            viewCoursegroup.CourseId = new SelectList(db.CourseContents, "CourseId", "CourseName", viewCoursegroup.CourseId);
            viewCoursegroup.TeacherId = new SelectList(db.EmployeeAccounts, "AccountId", "EmployeeCatagoryId", viewCoursegroup.TeacherId);
            return View(viewCoursegroup);
        }

        public ActionResult LoadCourseSchedule(string classId, string courseId)
        {
            ViewCourseGroup objViewCourseGroup = new ViewCourseGroup();
            List<ViewCourseGroupSchedule> objViewCourseGroupSchedule = new List<ViewCourseGroupSchedule>();
            var data = (from s in db.ScheduleInformations
                        select new
                        {
                            ScheduleId = s.ShScheduleId,
                            roomNo = s.RoomInformation.RmRoomNo,
                            SHDay = s.ShDay,
                            FromTime = s.ShFromTime,
                            ToTime = s.ShToTime,
                            ClassId = s.ShClass
                        });
            foreach (var item in data)
            {
                var fromTime = item.FromTime.Value.ToString("h:mm tt", CultureInfo.CreateSpecificCulture("en-BD"));
                var toTime = item.ToTime.Value.ToString("h:mm tt", CultureInfo.CreateSpecificCulture("en-BD"));

                var schedule = item.roomNo + " " + item.SHDay + " " + fromTime + "-" + toTime;
                objViewCourseGroupSchedule.Add(new ViewCourseGroupSchedule());
                objViewCourseGroupSchedule[objViewCourseGroupSchedule.Count - 1].ScheduleId = item.ScheduleId;
                objViewCourseGroupSchedule[objViewCourseGroupSchedule.Count - 1].Schedule = schedule;
                objViewCourseGroupSchedule[objViewCourseGroupSchedule.Count - 1].ShClass = item.ClassId;

            }
            objViewCourseGroup.CourseGroupScheduleList = objViewCourseGroupSchedule;
            objViewCourseGroup.ScheduleIno = new SelectList(objViewCourseGroupSchedule.Where(s =>s.ShClass == classId), "ScheduleId", "Schedule");
            objViewCourseGroup.ClassId = new SelectList(db.ClassOrYears, "Code", "Name", classId);
            objViewCourseGroup.CourseId = new SelectList(db.CourseContents.Where(s => s.ClassId == classId).ToList(), "CourseId", "CourseName");
            objViewCourseGroup.TeacherId = new SelectList(db.EmployeeAccounts, "AccountId", "EmployeeCatagoryId");
            return View(objViewCourseGroup);
            //return RedirectToAction("Create");
        }
        // GET: CourseGroup/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseGroup courseGroup = db.CourseGroups.Find(id);
            if (courseGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassOrYears, "Code", "Name", courseGroup.ClassId);
            ViewBag.CourseId = new SelectList(db.CourseContents, "CourseId", "CourseName", courseGroup.CourseId);
            ViewBag.TeacherId = new SelectList(db.EmployeeAccounts, "AccountId", "EmployeeCatagoryId", courseGroup.TeacherId);
            return View(courseGroup);
        }

        // POST: CourseGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,GroupId,TeacherId,TeacherId1,TeacherId2,Capacity,StudentCount,ClassId,SectionGroup,DayTimeSlot,Sex")] CourseGroup courseGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassOrYears, "Code", "Name", courseGroup.ClassId);
            ViewBag.CourseId = new SelectList(db.CourseContents, "CourseId", "CourseName", courseGroup.CourseId);
            ViewBag.TeacherId = new SelectList(db.EmployeeAccounts, "AccountId", "EmployeeCatagoryId", courseGroup.TeacherId);
            return View(courseGroup);
        }

        // GET: CourseGroup/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseGroup courseGroup = db.CourseGroups.Find(id);
            if (courseGroup == null)
            {
                return HttpNotFound();
            }
            return View(courseGroup);
        }

        // POST: CourseGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CourseGroup courseGroup = db.CourseGroups.Find(id);
            db.CourseGroups.Remove(courseGroup);
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
