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
    public class RoomInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoomInformation
        public ActionResult Index()
        {
            return View(db.RoomInformations.ToList());
        }

        // GET: RoomInformation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            if (roomInformation == null)
            {
                return HttpNotFound();
            }
            return View(roomInformation);
        }

        // GET: RoomInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RmRoomId,RmRoomNo,RmFloorNo,RmCapacity,RmDescription,RmCampus")] RoomInformation roomInformation)
        {
            if (ModelState.IsValid)
            {
                db.RoomInformations.Add(roomInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomInformation);
        }

        // GET: RoomInformation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            if (roomInformation == null)
            {
                return HttpNotFound();
            }
            return View(roomInformation);
        }

        // POST: RoomInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RmRoomId,RmRoomNo,RmFloorNo,RmCapacity,RmDescription,RmCampus")] RoomInformation roomInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomInformation);
        }

        // GET: RoomInformation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            if (roomInformation == null)
            {
                return HttpNotFound();
            }
            return View(roomInformation);
        }

        // POST: RoomInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            db.RoomInformations.Remove(roomInformation);
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
