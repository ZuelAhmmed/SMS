using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Models;
using SMS.Models.DbModels;
using SMS.ViewModels;

namespace SMS.Controllers
{
    public class EmployeeAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MediaDbContext imagedb = new MediaDbContext();
        // GET: EmployeeAccount
        public ActionResult Index()
        {
            var employeeAccounts = db.EmployeeAccounts.Include(e => e.Designation).Include(e => e.Subject);
            return View(employeeAccounts.ToList());
        }

        // GET: EmployeeAccount/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            if (employeeAccount == null)
            {
                return HttpNotFound();
            }
            return View(employeeAccount);
        }

        // GET: EmployeeAccount/Create
        public ActionResult Create()
        {
            ViewTeacherAccount objViewTeacherAccount = new ViewTeacherAccount();
            objViewTeacherAccount.Designation = new SelectList(db.Designations, "DesignationCode", "Name");
            objViewTeacherAccount.Subject = new SelectList(db.Subjects, "SubjectCode", "Name");
            return View(objViewTeacherAccount);
        }

        // POST: EmployeeAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeAccount")] ViewTeacherAccount objViewTeacherAccount,
            FormCollection collection, HttpPostedFileBase image)
        {
            SMS.Models.MediaModels.Image objImage = new SMS.Models.MediaModels.Image();
            EmployeeEducationalQualification objEmployeeEducationalQualification =
                new EmployeeEducationalQualification();
            var exam = collection["Exam"].Split(',');
            var institute = collection["Institute"].Split(',');
            var regNo = collection["Registration"].Split(',');
            var rollNo = collection["Roll"].Split(',');
            var group = collection["Group"].Split(',');
            var year = collection["Year"].Split(',');
            var grade = collection["Grade"].Split(',');


            if (image != null)
            {
                ////attach the uploaded image to the object before saving to Database
                //objImage.ImageMimeType = image.ContentLength;
                objImage.ImageFile = new byte[image.ContentLength];
                image.InputStream.Read(objImage.ImageFile, 0, image.ContentLength);

                //Save image to file
                var filename = image.FileName;
                var filePathOriginal = Server.MapPath("/Data/Image");
                var filePathThumbnail = Server.MapPath("/Data/Thumbnails");
                string savedFileName = Path.Combine(filePathOriginal, filename);
                image.SaveAs(savedFileName);

                //Read image back from file and create thumbnail from it
                var imageFile = Path.Combine(Server.MapPath("~/Data/Image"), filename);
                using (var srcImage = System.Drawing.Image.FromFile(imageFile))
                using (var newImage = new Bitmap(100, 100))
                using (var graphics = Graphics.FromImage(newImage))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, 200, 200));
                    newImage.Save(stream, ImageFormat.Png);
                    var thumbNew = File(stream.ToArray(), "image/png");
                    //artwork.ArtworkThumbnail = thumbNew.FileContents;
                }

                objImage.TrackingId = objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo;
                //Save model object to database
                imagedb.Images.Add(objImage);
                imagedb.SaveChanges();

            }
            for (int i = 0; i < exam.Count(); i++)
                {
                    if (exam[i] != "")
                    {
                        objEmployeeEducationalQualification.NidOrBirtgRegNo =
                            objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo;
                        objEmployeeEducationalQualification.ExamOrDegree = exam[i];
                        objEmployeeEducationalQualification.RegNumber = regNo[i];
                        objEmployeeEducationalQualification.RollNumber = rollNo[i];
                        objEmployeeEducationalQualification.InstituteName = institute[i];
                        objEmployeeEducationalQualification.PassingYear = year[i];
                        objEmployeeEducationalQualification.Group = group[i];
                        objEmployeeEducationalQualification.GpaOrDivison = grade[i];
                        db.EmployeeEducationalQualifications.Add(objEmployeeEducationalQualification);
                        db.SaveChanges();
                    }
                }

                if (ModelState.IsValid)
                {
                    db.EmployeeAccounts.Add(objViewTeacherAccount.EmployeeAccount);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                objViewTeacherAccount.Designation = new SelectList(db.Designations, "DesignationCode", "Name",
                    objViewTeacherAccount.Designation);
                objViewTeacherAccount.Subject = new SelectList(db.Subjects, "SubjectCode", "Name",
                    objViewTeacherAccount.Subject);
                return View(objViewTeacherAccount);
            }



        public FileContentResult GetThumbnailImage(string nId)
        {
            SMS.Models.MediaModels.Image objImage = imagedb.Images.FirstOrDefault(p => p.TrackingId == nId);
            if (objImage != null)
            {
                return File(objImage.ImageFile, "png");
            }
            else
            {
                return null;
            }
        }

        // GET: EmployeeAccount/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            ViewTeacherAccount objViewTeacherAccount = new ViewTeacherAccount();
           // EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            objViewTeacherAccount.EmployeeAccount = db.EmployeeAccounts.Find(id);
            if (objViewTeacherAccount.EmployeeAccount == null)
            {
                return HttpNotFound();
            }
            objViewTeacherAccount.EmployeeEducationalQualifications = db.EmployeeEducationalQualifications.Where(s => s.NidOrBirtgRegNo == objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo).ToList();
            objViewTeacherAccount.Designation = new SelectList(db.Designations, "DesignationCode", "Name", objViewTeacherAccount.Designation);
            objViewTeacherAccount.Subject = new SelectList(db.Subjects, "SubjectCode", "Name", objViewTeacherAccount.Subject);
            return View(objViewTeacherAccount);
        }

        // POST: EmployeeAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeAccount")] ViewTeacherAccount objViewTeacherAccount, FormCollection collection, HttpPostedFileBase image)
        {
            SMS.Models.MediaModels.Image objImage = new SMS.Models.MediaModels.Image();
            if (image != null)
            {
                ////attach the uploaded image to the object before saving to Database
                //objImage.ImageMimeType = image.ContentLength;
                objImage.ImageFile = new byte[image.ContentLength];
                image.InputStream.Read(objImage.ImageFile, 0, image.ContentLength);
                //Save image to file
                var filename = image.FileName;
                var filePathOriginal = Server.MapPath("/Data/Image");
                var filePathThumbnail = Server.MapPath("/Data/Thumbnails");
                string savedFileName = Path.Combine(filePathOriginal, filename);
                image.SaveAs(savedFileName);

                //Read image back from file and create thumbnail from it
                var imageFile = Path.Combine(Server.MapPath("~/Data/Image"), filename);
                using (var srcImage = System.Drawing.Image.FromFile(imageFile))
                using (var newImage = new Bitmap(100, 100))
                using (var graphics = Graphics.FromImage(newImage))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, 200, 200));
                    newImage.Save(stream, ImageFormat.Png);
                    var thumbNew = File(stream.ToArray(), "image/png");
                    //artwork.ArtworkThumbnail = thumbNew.FileContents;
                }

                SMS.Models.MediaModels.Image objImg = imagedb.Images.FirstOrDefault(p => p.TrackingId == objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo);
                if (objImg == null)
                {
                    objImage.TrackingId = objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo;
                    imagedb.Images.Add(objImage);
                    imagedb.SaveChanges();
                }
                else
                {
                    objImg.TrackingId = objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo;
                    objImg.ImageFile = objImage.ImageFile;
                    imagedb.Entry(objImg).State = EntityState.Modified;
                    imagedb.SaveChanges();
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(objViewTeacherAccount.EmployeeAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            objViewTeacherAccount.EmployeeEducationalQualifications = db.EmployeeEducationalQualifications.Where(s => s.NidOrBirtgRegNo == objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo).ToList();
            objViewTeacherAccount.Designation = new SelectList(db.Designations, "DesignationCode", "Name", objViewTeacherAccount.Designation);
            objViewTeacherAccount.Subject = new SelectList(db.Subjects, "SubjectCode", "Name", objViewTeacherAccount.Subject);
            return View(objViewTeacherAccount);
        }

        // GET: EmployeeAccount/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            if (employeeAccount == null)
            {
                return HttpNotFound();
            }
            return View(employeeAccount);
        }

        // POST: EmployeeAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeAccount employeeAccount = db.EmployeeAccounts.Find(id);
            db.EmployeeAccounts.Remove(employeeAccount);
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
