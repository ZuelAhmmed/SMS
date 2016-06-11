using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Gender
    {
        [Key]
        public string GenderCode { get; set; }

        [DisplayName("Gender Name")]
        [Required(ErrorMessage = "Gender Name Required.")]
        public string Name { get; set; }
    }


    public class Religion
    {
        [Key]
        public string ReligionCode { get; set; }

        [DisplayName("Religion Name")]
        [Required(ErrorMessage = "Type Religion Name")]
        public string Name { get; set; }
    }

    public class BloodGroup
    {
        [Key]
        public string BloodGroupCode { get; set; }

        [DisplayName("Group Name")]
        [Required(ErrorMessage = "Type Blood Group")]
        public string Name { get; set; }
    }

    public class MaritarialStatus
    {
        [Key]
        public string MaritarialStatusCode { get; set; }

        [DisplayName("Maritarial Status Name")]
        [Required(ErrorMessage = "Type Maritarial Status Name")]
        public string Name { get; set; }
    }
}