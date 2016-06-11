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
using SMS.Security;
using SMS.ViewModels;

namespace SMS.Controllers
{
    public class StudentAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MediaDbContext imagedb = new MediaDbContext();
       //
        // GET: StudentAccount
        public ActionResult Index()
        {
            var studentAccounts = db.StudentAccounts.Include(s => s.ClassOrYears).Include(s => s.Gorups);
            return View(studentAccounts.ToList());
        }

        // GET: StudentAccount/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAccount studentAccount = db.StudentAccounts.Find(id);
            if (studentAccount == null)
            {
                return HttpNotFound();
            }
            return View(studentAccount);
        }

        // GET: StudentAccount/Create
        public ActionResult Create()
        {

            ViewStudentAccount objStudentAccount = new ViewStudentAccount();
            objStudentAccount.Class = new SelectList(db.ClassOrYears, "Code", "Name");
            objStudentAccount.Group = new SelectList(db.Groups, "GroupCode", "Name");

            if (TempData["Student"] != null)
            {
                var stdudentData = (ApplicationUser)TempData["Student"];
              //  objStudentAccount = (ApplicationUser)TempData["Student"];
                objStudentAccount.AccountId = stdudentData.Id;
                objStudentAccount.Nid = stdudentData.NidOrBirthRegNo;
                objStudentAccount.FirstName = stdudentData.FirstName;
                objStudentAccount.LastName = stdudentData.LastName;
                objStudentAccount.Phone = stdudentData.PhoneNumber;
                objStudentAccount.DateOfBirth = stdudentData.DateOfBirth;

                //objStudentAccount = stdudentData;

            }
            return View(objStudentAccount);
        }

        // POST: StudentAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentAccount,Nid,FirstName,LastName,Phone,AccountId,DateOfBirth")]  ViewStudentAccount objStudentAccount,FormCollection collection, HttpPostedFileBase image)
        {
            SMS.Models.MediaModels.Image objImage = new SMS.Models.MediaModels.Image();
            StudentEducationalQualification objStudentEducationalQualification = new StudentEducationalQualification();


            var exam = collection["Exam"].Split(',');
            var institute = collection["Institute"].Split(',');
            var regNo = collection["Registration"].Split(',');
            var rollNo = collection["Roll"].Split(',');
            var group = collection["Group"].Split(',');
            var year = collection["Year"].Split(',');        
            var grade = collection["Grade"].Split(',');
            
            //var registration = collection["Registration"].Split(',');


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

                objImage.TrackingId = objStudentAccount.Nid;
                //Save model object to database
                imagedb.Images.Add(objImage);
                imagedb.SaveChanges();
            }

            objStudentAccount.StudentAccount.NidOrBirtgRegNo = objStudentAccount.Nid;
            objStudentAccount.StudentAccount.AccountId = objStudentAccount.AccountId;
            objStudentAccount.StudentAccount.FirstName = objStudentAccount.FirstName;
            objStudentAccount.StudentAccount.LasttName = objStudentAccount.LastName;
            objStudentAccount.StudentAccount.MobileNumber = objStudentAccount.Phone;
            objStudentAccount.StudentAccount.DateOfBirth = objStudentAccount.DateOfBirth;



            for (int i = 0; i < exam.Count(); i++)
            {
                if (exam[i] != "")
                {                  
                    objStudentEducationalQualification.NidOrBirtgRegNo = objStudentAccount.StudentAccount.NidOrBirtgRegNo;
                    objStudentEducationalQualification.ExamOrDegree = exam[i];
                    objStudentEducationalQualification.RegNumber = regNo[i];
                    objStudentEducationalQualification.RollNumber = rollNo[i];
                    objStudentEducationalQualification.InstituteName = institute[i];
                    objStudentEducationalQualification.PassingYear = year[i];
                    objStudentEducationalQualification.Group = group[i];
                    objStudentEducationalQualification.GpaOrDivison = grade[i];
                    db.StudentEducationalQualifications.Add(objStudentEducationalQualification);
                    db.SaveChanges();
                }
            }
            if (ModelState.IsValid)
            {

               

                db.StudentAccounts.Add(objStudentAccount.StudentAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
           }

            objStudentAccount.Class = new SelectList(db.ClassOrYears, "Code", "Name", objStudentAccount.StudentAccount.ClassOrYearId);
            objStudentAccount.Group = new SelectList(db.Groups, "GroupCode", "Name", objStudentAccount.StudentAccount.GroupId);
            return View(objStudentAccount);
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

        // GET: StudentAccount/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewStudentAccount objViewStudentAccount = new ViewStudentAccount();
          
             objViewStudentAccount.StudentAccount = db.StudentAccounts.Find(id);
           // StudentAccount studentAccount = db.StudentAccounts.Find(id);
             if (objViewStudentAccount.StudentAccount == null)
            {
                return HttpNotFound();
            }
             objViewStudentAccount.StudentEducationalQualifications = db.StudentEducationalQualifications.Where(s => s.NidOrBirtgRegNo == objViewStudentAccount.StudentAccount.NidOrBirtgRegNo).ToList();
            objViewStudentAccount.Class = new SelectList(db.ClassOrYears, "Code", "Name", objViewStudentAccount.StudentAccount.ClassOrYearId);
            objViewStudentAccount.Group = new SelectList(db.Groups, "GroupCode", "Name", objViewStudentAccount.StudentAccount.GroupId);
            return View(objViewStudentAccount);
        }

        // POST: StudentAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentAccount")] ViewStudentAccount objViewStudentAccount,FormCollection collection, HttpPostedFileBase image)
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
             
                SMS.Models.MediaModels.Image objImg = imagedb.Images.FirstOrDefault(p => p.TrackingId == objViewStudentAccount.StudentAccount.NidOrBirtgRegNo);
                if (objImg == null)
                {               
                    objImage.TrackingId = objViewStudentAccount.StudentAccount.NidOrBirtgRegNo;
                    imagedb.Images.Add(objImage);
                    imagedb.SaveChanges();
                }
                else
                {
                    objImg.TrackingId = objViewStudentAccount.StudentAccount.NidOrBirtgRegNo;
                    objImg.ImageFile = objImage.ImageFile;
                    imagedb.Entry(objImg).State = EntityState.Modified;
                    imagedb.SaveChanges();
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(objViewStudentAccount.StudentAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            objViewStudentAccount.StudentEducationalQualifications = db.StudentEducationalQualifications.Where(s => s.NidOrBirtgRegNo == objViewStudentAccount.StudentAccount.NidOrBirtgRegNo).ToList();
            objViewStudentAccount.Class = new SelectList(db.ClassOrYears, "Code", "Name", objViewStudentAccount.StudentAccount.ClassOrYearId);
            objViewStudentAccount.Group = new SelectList(db.Groups, "GroupCode", "Name", objViewStudentAccount.StudentAccount.GroupId);
            return View(objViewStudentAccount);
        }

        // GET: StudentAccount/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAccount studentAccount = db.StudentAccounts.Find(id);
            if (studentAccount == null)
            {
                return HttpNotFound();
            }
            return View(studentAccount);
        }

        // POST: StudentAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {          
            StudentAccount studentAccount = db.StudentAccounts.Find(id);
            db.StudentAccounts.Remove(studentAccount);
            db.SaveChanges();
            return RedirectToAction("Index");             
        }






        [HttpPost]
        public ActionResult Save(string exam, string institute, string group, string year, string grade, long id)
        {
            if (ModelState.IsValid)
            {
               // var data = db.StudentEducationInfos.Find(Id);
                var data = db.StudentEducationalQualifications.Find(id);

                data.ExamOrDegree = exam;
                data.InstituteName = institute;
                data.Group = group;
                data.PassingYear = year;
                data.GpaOrDivison = grade;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult NewSave(string exam, string institute, string group, string year, string grade, string studentNid)
        {
         //   StudentEducationInfo objStudentEducationInfo = new StudentEducationInfo();
            StudentEducationalQualification objStudentEducationalQualification = new StudentEducationalQualification();
            if (ModelState.IsValid)
            {
                var stdId = studentNid;
                //var frmSlNo = Convert.ToInt64(FormSaleInfo_FormSerial);
                objStudentEducationalQualification.NidOrBirtgRegNo = stdId;

                objStudentEducationalQualification.ExamOrDegree = exam;
                objStudentEducationalQualification.InstituteName = institute;
                objStudentEducationalQualification.Group = group;
                objStudentEducationalQualification.PassingYear = year;
                objStudentEducationalQualification.GpaOrDivison = grade;
                db.StudentEducationalQualifications.Add(objStudentEducationalQualification);
                db.SaveChanges();

                //var Id = db.StudentEducationInfos.Where(S => S.StudentId == stdId && S.Exam == Exam && S.InstitutionName == Institute &&
                //                                    S.GroupName == Group && S.PassingYear == Year && S.DivisionClass == Grade).Select(S => S.Id);

                var Id =
                    db.StudentEducationalQualifications.Where(
                        s => s.NidOrBirtgRegNo == stdId && s.ExamOrDegree == exam && s.InstituteName == institute &&
                             s.Group == group && s.PassingYear == year && s.GpaOrDivison == grade)
                            .Select(s => s.Id)
                            .FirstOrDefault();


               return Json(new { result = Id }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = "error" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost, ActionName("StudentEducationDelete")]
        public ActionResult StudentEducationDelete(long id)
        {
            StudentEducationalQualification objStudentEducationalQualification = db.StudentEducationalQualifications.Find(id);
           // StudentEducationalQualification objStudentEducationalQualification = new StudentEducationalQualification();
            if (objStudentEducationalQualification != null)
            {
                db.StudentEducationalQualifications.Remove(objStudentEducationalQualification);
                db.SaveChanges();
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
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
