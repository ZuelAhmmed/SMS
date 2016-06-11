using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class EducationBoard
    {
        [Key]
        public string BoardCode { get; set; } 

        [DisplayName("Board Name")]
        [Required(ErrorMessage = "Type Board Name.")]
        public string Name { get; set; }
    }

    public class ClassOrYear
    {
        public ClassOrYear()
        {
            
        }

        public ClassOrYear(string id, string className) : this()
        {
            Code = id;
            Name = className;
        }
        [Key]
        public string Code { get; set; }
        
        [DisplayName("Class Name")]
        [Required(ErrorMessage = "Type Class Name.")]
        public string Name { get; set; }

        public virtual ICollection<StudentAttendence> StudentAttendences { get; set; } 
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<StudentApplication> StudentApplications { get; set; }


    }

    public class Group
    {
        [Key]
        public string GroupCode { get; set; }

        [DisplayName("Group Name")]
        [Required(ErrorMessage = "Sector Name Is Required.")]
        public string Name { get; set; }

        public virtual ICollection<StudentApplication> StudentApplications { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }

    public class Shift
    {
        [Key]
        public string ShiftCode { get; set; }

        [DisplayName("Shift")]
        [Required(ErrorMessage = "Type Shift Name.")]
        public string Name { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }

    public class Section
    {
        [Key]
        public string SectionCode { get; set; }

        [DisplayName("Section Name")]
        [Required(ErrorMessage = "Type Section Name.")]
        public string Name { get; set; }

        public string ShiftCode { get; set; }

        [ForeignKey("ShiftCode")]
        public virtual Section Sections { get; set; }
    }

    public class ExamYear
    {
        [Key]
        public string ExamYearCode { get; set; }

        [DisplayName("Year")]
        [Required(ErrorMessage = "Add Year Name.")]
        public string Name { get; set; }
    }

    public class SubjectCatagory
    {
        [Key]
        public string SubCatCode { get; set; }

        [DisplayName("Subject Catagory Name")]
        [Required(ErrorMessage = "Type Subject Catagory")]
        public string Name { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        [Key]
        [Required(ErrorMessage = "Type Sybject Code")]
        public string SubjectCode { get; set; }

        [DisplayName("Subject Name")]
        [Required(ErrorMessage = "Type Sybject Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Class")]
        public string ClassId { get; set; }

        [Required(ErrorMessage = "Select Group")]
        public string GroupId { get; set; }

        [Required(ErrorMessage = "Select Catagory")]
        public string CatagoryId { get; set; }

        [ForeignKey("ClassId")]
        public virtual ClassOrYear ClassOrYear { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        [ForeignKey("CatagoryId")]
        public virtual SubjectCatagory SubjectCatagory { get; set; }
    }
}