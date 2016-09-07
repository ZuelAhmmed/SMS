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
    public class ScheduleInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScheduleInformation
        public ActionResult Index(string classId)
        {
            ViewBag.ClassId = new SelectList(db.ClassOrYears,"Code","Name");
            var scheduleInformations = db.ScheduleInformations.Include(s => s.RoomInformation);
            return View(scheduleInformations.Where(s => s.ShClass == classId).ToList());
        }

        // GET: ScheduleInformation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleInformation scheduleInformation = db.ScheduleInformations.Find(id);
            if (scheduleInformation == null)
            {
                return HttpNotFound();
            }
            return View(scheduleInformation);
        }

        // GET: ScheduleInformation/Create
        public ActionResult Create(string classId)
        {
            ViewSchedule objViewSchedule = new ViewSchedule();
            List<ViewScheduleInformation> objScheduleInformation = new List<ViewScheduleInformation>();
            objViewSchedule.ClassId = new SelectList(db.ClassOrYears, "Code", "Name", classId);
            ViewBag.RmRoomId = new SelectList(db.RoomInformations, "RmRoomId", "RmRoomNo");
            objViewSchedule.RoomInformation = db.RoomInformations.ToList();

            if (String.IsNullOrEmpty(classId))
            //if (classId == null || classId == "")
            {
                var schedule = db.ScheduleInformations.Where(w => w.ShClass == classId).Select(s => new { s.ShFromTime, s.ShToTime }).Distinct().ToList();
                foreach (var item in schedule)
                {
                    objScheduleInformation.Add(new ViewScheduleInformation());
                    objScheduleInformation[objScheduleInformation.Count - 1].ShFromTime = item.ShFromTime.GetValueOrDefault();
                    objScheduleInformation[objScheduleInformation.Count - 1].ShToTime = item.ShToTime.GetValueOrDefault();

                }
            }
            else
            {
                var sc = (from S in db.ScheduleInformations
                    where S.ShClass == classId
                    select new
                    {
                        fromTime = S.ShFromTime,
                        toTime = S.ShToTime
                    }).Distinct().ToList();
                //var schedule = db.ScheduleInformations.Where(w => w.ShClass == classId).Select(s => new { s.ShFromTime, s.ShToTime }).Distinct().ToList();
                foreach (var item in sc)
                {
                    objScheduleInformation.Add(new ViewScheduleInformation());
                    objScheduleInformation[objScheduleInformation.Count - 1].ShFromTime = item.fromTime.GetValueOrDefault();
                    objScheduleInformation[objScheduleInformation.Count - 1].ShToTime = item.toTime.GetValueOrDefault();
                }
            }
            objViewSchedule.ScheduleInformation = objScheduleInformation;

            return View(objViewSchedule);
        }

        // POST: ScheduleInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ShScheduleId,RmRoomId,ShClass,ShDay,ShFromTime,ShToTime,ShCourse,ShSection")] ScheduleInformation scheduleInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ScheduleInformations.Add(scheduleInformation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.RmRoomId = new SelectList(db.RoomInformations, "RmRoomId", "RmRoomNo", scheduleInformation.RmRoomId);
        //    return View(scheduleInformation);
        //}





        //[HttpPost]
        //[ValidateAntiForgeryToken]
         [HttpPost, ActionName("Create")]
        public ActionResult Create(string roomId, string day, string time, string classId)
        {
            ScheduleInformation scheduleinformation = new ScheduleInformation();
            var date = time.Split('-');
            var rMRoomId = Convert.ToInt64(roomId);
            var sHFromTime = Convert.ToDateTime(date[0]);
            var sHToTime = Convert.ToDateTime(date[1]);
            var dpRoom  = db.ScheduleInformations.Where(w => w.RmRoomId == rMRoomId && w.ShDay == day &&
                                             (w.ShFromTime >= sHFromTime && w.ShToTime <= sHToTime)).ToList();

            var data = db.ScheduleInformations.Where(w => w.RmRoomId == rMRoomId && w.ShDay == day && w.ShClass == classId &&
                                               (w.ShFromTime >= sHFromTime && w.ShToTime <= sHToTime)).ToList();
            if (data.Count == 0 && dpRoom.Count == 0)
            {
                var year = DateTime.Now.Year;

                scheduleinformation.RmRoomId = Convert.ToInt64(roomId);
                scheduleinformation.ShDay = day;
                scheduleinformation.ShFromTime = Convert.ToDateTime(date[0]);
                scheduleinformation.ShToTime = Convert.ToDateTime(date[1]);
                scheduleinformation.ShClass = classId;
                scheduleinformation.Year = Convert.ToString(year);
                db.ScheduleInformations.Add(scheduleinformation);
                db.SaveChanges();

            }
            return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
        }

        // GET: ScheduleInformation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleInformation scheduleInformation = db.ScheduleInformations.Find(id);
            if (scheduleInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.RmRoomId = new SelectList(db.RoomInformations, "RmRoomId", "RmRoomNo", scheduleInformation.RmRoomId);
            return View(scheduleInformation);
        }

        // POST: ScheduleInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShScheduleId,RmRoomId,ShClass,ShDay,ShFromTime,ShToTime,ShCourse,ShSection")] ScheduleInformation scheduleInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RmRoomId = new SelectList(db.RoomInformations, "RmRoomId", "RmRoomNo", scheduleInformation.RmRoomId);
            return View(scheduleInformation);
        }

        // GET: ScheduleInformation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleInformation scheduleInformation = db.ScheduleInformations.Find(id);
            if (scheduleInformation == null)
            {
                return HttpNotFound();
            }
            return View(scheduleInformation);
        }

        // POST: ScheduleInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ScheduleInformation scheduleInformation = db.ScheduleInformations.Find(id);
            db.ScheduleInformations.Remove(scheduleInformation);
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
