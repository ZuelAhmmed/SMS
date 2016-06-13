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
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using SMS.Models.DbModels;

namespace SMS.Controllers
{
    public class TeacherAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MediaDbContext imagedb = new MediaDbContext();

        // GET: TeacherAccount
        public ActionResult Index()
        {
            var employeeAccounts = db.EmployeeAccounts.Include(e => e.Designation).Include(e => e.Subject);
            return View(employeeAccounts.ToList());
        }

        // GET: TeacherAccount/Details/5
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

        // GET: TeacherAccount/Create
        public ActionResult Create()
        {
            ViewTeacherAccount objViewTeacherAccount = new ViewTeacherAccount();

            objViewTeacherAccount.Designation = new SelectList(db.Designations, "DesignationCode", "Name");
            objViewTeacherAccount.Subject = new SelectList(db.Subjects, "SubjectCode", "Name");


            if (TempData["Teacher"] != null)
            {
                var teacherData = (ApplicationUser)TempData["Teacher"];
                //  objViewTeacherAccount = (ApplicationUser)TempData["Student"];
                objViewTeacherAccount.AccountId = teacherData.Id;
                objViewTeacherAccount.Nid = teacherData.NidOrBirthRegNo;
                objViewTeacherAccount.FirstName = teacherData.FirstName;
                objViewTeacherAccount.LastName = teacherData.LastName;
                objViewTeacherAccount.Phone = teacherData.PhoneNumber;
                objViewTeacherAccount.DateOfBirth = teacherData.DateOfBirth;

                //objStudentAccount = stdudentData;

            }


            return View(objViewTeacherAccount);
        }

        // POST: TeacherAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeAccount,Nid,FirstName,LastName,Phone,AccountId,DateOfBirth")] ViewTeacherAccount objViewTeacherAccount, FormCollection collection, HttpPostedFileBase image)
        {

            SMS.Models.MediaModels.Image objImage = new SMS.Models.MediaModels.Image();
            EmployeeEducationalQualification objTeacherEducationalQualification = new EmployeeEducationalQualification();


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

                objImage.TrackingId = objViewTeacherAccount.Nid;
                //Save model object to database
                imagedb.Images.Add(objImage);
                imagedb.SaveChanges();
            }


            objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo = objViewTeacherAccount.Nid;
            objViewTeacherAccount.EmployeeAccount.AccountId = objViewTeacherAccount.AccountId;
            objViewTeacherAccount.EmployeeAccount.FirstName = objViewTeacherAccount.FirstName;
            objViewTeacherAccount.EmployeeAccount.LasttName = objViewTeacherAccount.LastName;
            objViewTeacherAccount.EmployeeAccount.MobileNumber = objViewTeacherAccount.Phone;
            objViewTeacherAccount.EmployeeAccount.DateOfBirth = objViewTeacherAccount.DateOfBirth;



            for (int i = 0; i < exam.Count(); i++)
            {
                if (exam[i] != "")
                {
                    objTeacherEducationalQualification.NidOrBirtgRegNo = objViewTeacherAccount.EmployeeAccount.NidOrBirtgRegNo;
                    objTeacherEducationalQualification.ExamOrDegree = exam[i];
                   
                   
                    objTeacherEducationalQualification.InstituteName = institute[i];
                    objTeacherEducationalQualification.PassingYear = year[i];
                    
                    objTeacherEducationalQualification.GpaOrDivison = grade[i];
                    db.EmployeeEducationalQualifications.Add(objTeacherEducationalQualification);
                    db.SaveChanges();
                }
            }

            if (ModelState.IsValid)
            {



                db.EmployeeAccounts.Add(objViewTeacherAccount.EmployeeAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            objViewTeacherAccount.Designation = new SelectList(db.Designations, "DesignationCode", "Name", objViewTeacherAccount.EmployeeAccount.DesignationId);
            objViewTeacherAccount.Subject = new SelectList(db.Subjects, "SubjectCode", "Name", objViewTeacherAccount.EmployeeAccount.SubjectCode);
            return View(objViewTeacherAccount);
        }

        // GET: TeacherAccount/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationCode", "Name", employeeAccount.DesignationId);
            ViewBag.SubjectCode = new SelectList(db.Subjects, "SubjectCode", "Name", employeeAccount.SubjectCode);
            return View(employeeAccount);
        }

        // POST: TeacherAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,EmployeeCatagoryId,DesignationId,SubjectCode,IndexNumber,ConfirmationId,ConfirmDate,ConfirmedBy,RetiredDate,NidOrBirtgRegNo,EmailAddress,MobileNumber,FirstName,LasttName,OccupationId,FathersName,FathersOccupation,MothersName,MothersOccupation,DateOfBirth,PresentAddress,PermanentAddress,MaritarialStatus,Gender,Religion,BloodGroup,Nationality,RegDateTime,LastLoginDateTime")] EmployeeAccount employeeAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationCode", "Name", employeeAccount.DesignationId);
            ViewBag.SubjectCode = new SelectList(db.Subjects, "SubjectCode", "Name", employeeAccount.SubjectCode);
            return View(employeeAccount);
        }

        // GET: TeacherAccount/Delete/5
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

        // POST: TeacherAccount/Delete/5
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
