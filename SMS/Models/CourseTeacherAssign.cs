using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class CourseTeacherAssign
    {
        public int Id { get; set; }
        public string NidOrBirthRegNo { get; set; }
        public string SubjectId { get; set; }
        public string ClassOrYearId { get; set; }
        public string YearOfExam { get; set; }
    }
}