using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.ViewModels
{
    public class ViewStudentAttendence
    {
        public SelectList Class { get; set; }
        public StudentAttendence StudentAttendence { get; set; }
        public List<StudentAttendence> StudentAttendenceList { get; set; }
        public int TotalStudent { get; set; }
        public int TotalFemaleStudent { get; set; }



    }
}