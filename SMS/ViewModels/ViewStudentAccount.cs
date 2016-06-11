using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;


namespace SMS.ViewModels
{
    public class ViewStudentAccount
    {
      //  public ApplicationUser ApplicationUser { get; set; }

        public StudentAccount StudentAccount { get; set; }
        public SelectList Class { get; set; }
        public SelectList Group { get; set; }
        public List<StudentEducationalQualification> StudentEducationalQualifications { get; set; }

        public string Nid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AccountId { get; set; }
        public DateTime DateOfBirth { get; set; }




    }



}


 