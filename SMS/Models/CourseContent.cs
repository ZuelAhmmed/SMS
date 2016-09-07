using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SMS.Models
{
    public class CourseContent
    {

        public CourseContent()
        {
            this.CourseGroups = new HashSet<CourseGroup>();
        }

        [Key]
        [Required(ErrorMessage = "CourseId is Required")]
        [RegularExpression("([a-zA-Z0-9 .&'_'-]+)", ErrorMessage = " Slash(/) can't use.")]
        public string CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is Required")]
        public string CourseName { get; set; }
        public string CourseLevel { get; set; }
        public int? CourseType { get; set; }
        public string ClassId { get; set; }
        public string CourseCatagory { get; set; }
        public string Group { get; set; }

        public virtual ICollection<CourseGroup> CourseGroups { get; set; }

    }
}