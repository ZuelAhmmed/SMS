using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Models;
using System.Web.Mvc;

namespace SMS.ViewModels
{
    public class ViewTeacherAccount
    {
        public EmployeeAccount EmployeeAccount { set; get; }
        public SelectList Designation { set; get; }
        public SelectList Subject { set; get; }

        public List<EmployeeEducationalQualification> EmployeeEducationalQualifications { set; get; }

        public string Nid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AccountId { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}