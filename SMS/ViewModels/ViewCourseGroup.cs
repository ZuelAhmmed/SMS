using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.ViewModels
{
    public class ViewCourseGroup
    {
        public CourseGroup CourseGroup { get; set; }
        public SelectList ClassId { get; set; }
        public SelectList TeacherId { get; set; }
        public SelectList CourseId { get; set; }

        public SelectList ScheduleIno { get; set; }
        public List<ViewCourseGroupSchedule> CourseGroupScheduleList { get; set; }
        public IEnumerable<ScheduleInformation> ScheduleInformationT { get; set; }
      //  public string ScheduleId { get; set; }
      //  public string Schedule { get; set; }
    }
}