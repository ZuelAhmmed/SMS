using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class StudentAttendence
    {
        public int Id { get; set; }
        public string ClassOrYearId { get; set; }
        public int TotalStudent { get; set; }
        public int FemaleStudentNo { get; set; }
        public int TotalPresentStudent { get; set; }
        public int PresentFemaleStudent { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("ClassOrYearId")]
        public virtual ClassOrYear ClassOrYears { get; set; }
    }

    public class TeacherAttendence
    {
        public int Id { get; set; }
        public int TotalTeacher { get; set; }
        public int PresentTeacher { get; set; }
        public DateTime DateTime { get; set; }

    }
}