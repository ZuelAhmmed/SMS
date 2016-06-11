using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class StudentFacility
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("User NID/BirthRegNo")]
        public string NidOrBirtgRegNo { get; set; }

        public int Scholarship { get; set; }
    }
}