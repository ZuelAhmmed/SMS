using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class CourseGroup
    {
        public long Id { get; set; }
        public string CourseId  { get; set; }
        public string GroupId { get; set; }
        public string TeacherId { get; set; }
        public string TeacherId1 { get; set; }
        public string TeacherId2 { get; set; }
        public int? Capacity { get; set; }
        public int? StudentCount { get; set; }
        public string ClassId { get; set; }
        public string SectionGroup { get; set; }
        public string DayTimeSlot { get; set; }
        public string Sex { get; set; }


        [ForeignKey("CourseId")]
        public virtual CourseContent CourseContents { get; set; }
        [ForeignKey("ClassId")]
        public virtual ClassOrYear ClassOrYears { get; set; }
        [ForeignKey("TeacherId")]
        public virtual EmployeeAccount TeacherInfo { get; set; }

    }
}