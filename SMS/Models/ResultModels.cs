using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class PublicExamResult
    {
        public int Id { get; set; }
        public string ExamOrDegreeId { get; set; }
        public int ExamYear { get; set; }
        public int TotalStudent { get; set; }
        public int FemaleStudent { get; set; }
        public int PassedStudent { get; set; }
        public int FemalePassed { get; set; }
    }

    public class AcademicExamResult 
    {
        public int Id { get; set; }
        public string NidOrBirthRegNo { get; set; }
        public string ClassOrYearId { get; set; }
        public string SubjectId { get; set; }
        public decimal WritenMark { get; set; }
        public decimal McqTestMark { get; set; }
        public decimal PracticalMark { get; set; }
    }
}