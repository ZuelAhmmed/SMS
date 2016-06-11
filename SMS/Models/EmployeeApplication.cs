using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SMS.Security;

namespace SMS.Models
{
    public class EmployeeApplication : BasicAccount
    {
        public string EmployeeCatagoryId { get; set; }
        public string DesignationId { get; set; }
        public string SubjectCode { get; set; }
        public string ConfirmationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [ForeignKey("SubjectCode")]
        public virtual Subject Subject { get; set; }

       // [ForeignKey("EmployeeCatagoryId")]
      //  public virtual SecurityRole EmployeeCatagory { get; set; }

    }
}