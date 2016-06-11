using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SMS.Security;

namespace SMS.Models
{
    public class Occupation
    {
        [Key]
        public string Code { get; set; }

        [DisplayName("Occupation Name")]
        [Required(ErrorMessage = "Type an Occupation.")]
        public string Name { get; set; }

        public virtual ICollection<EmployeeApplication> EmployeeApplications { get; set; }
        public virtual ICollection<EmployeeAccount> EmployeeAccounts { get; set; }
        public virtual ICollection<StudentApplication> StudentApplications { get; set; }
        public virtual ICollection<StudentAccount> StudentAccounts { get; set; }
        public virtual ICollection<GuardianAccount> GuardianAccounts { get; set; }
    }

    public class Designation
    {
        [Key]
        public string DesignationCode { get; set; }

        [DisplayName("Designation Name")]
        [Required(ErrorMessage = "Type Designation")]
        public string Name { get; set; }

        public string EmployeeCatagoryId { get; set; }

        //[ForeignKey("EmployeeCatagoryId")]
        //public virtual SecurityRole EmployeeCatagory { get; set; }
    }
}