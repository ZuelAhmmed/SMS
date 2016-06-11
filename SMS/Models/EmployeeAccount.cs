using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SMS.Security;

namespace SMS.Models
{
    public class EmployeeAccount : BasicAccount
    {
        public string EmployeeCatagoryId { get; set; }
        public string DesignationId { get; set; }
        public string SubjectCode { get; set; }

        // Usable By The Administrator
        public string IndexNumber { get; set; }

        public string ConfirmationId { get; set; }

        public DateTime ConfirmDate { get; set; }

        public string ConfirmedBy { get; set; }

        public DateTime RetiredDate { get; set; }

        //[ForeignKey("EmployeeCatagoryId")]
        //public virtual SecurityRole EmployeeCatagory { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [ForeignKey("SubjectCode")]
        public virtual Subject Subject { get; set; }
    }
}