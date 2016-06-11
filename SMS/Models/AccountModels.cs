using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class BasicAccount
    {
        [Key]
        public string AccountId { get; set; }

        [DisplayName("NID/Birth Reg No")]
     //   [Required(ErrorMessage = "Type NID or Birth Reg No")]
        public string NidOrBirtgRegNo { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }
      
        //[RegularExpression("[0-9]", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Mobile Number")]
       // [Required(ErrorMessage = "Type Mobile Number")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Mobile Number containsmaximum 11 Digit.")]
        public string MobileNumber { get; set; }

        [DisplayName("First Name")]
      //  [Required(ErrorMessage = "Type Your First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
       // [Required(ErrorMessage = "Type Your Last Name")]
        public string LasttName { get; set; }

        //[Required(ErrorMessage = "Select Your Occupation")]
        public string OccupationId { get; set; }

        [DisplayName("Father's Name")]
        [Required(ErrorMessage = "Type Your Father's Name")]
        public string FathersName { get; set; }

        [Required(ErrorMessage = "Select Fathers Occupation")]
        public string FathersOccupation { get; set; }

        [DisplayName("Mother's Name")]
        [Required(ErrorMessage = "Type Your Mother's Name")]
        public string MothersName { get; set; }

        [Required(ErrorMessage = "Select Mothers Occupation.")]
        public string MothersOccupation { get; set; }

        [DisplayName("Date Of Birth")]
       // [Required(ErrorMessage = "Select Your Birth Date.")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Present Address")]
        [Required(ErrorMessage = "Select Your Present Address.")]
        public string PresentAddress { get; set; }

        [DisplayName("Permanent Address")]
        [Required(ErrorMessage = "Select Your Permanent Address.")]
        public string PermanentAddress { get; set; }

        [Required(ErrorMessage = "Select Your Maritarial Status.")]
        public string MaritarialStatus { get; set; }

        [Required(ErrorMessage = "Select Your Gender.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Select Your Religion.")]
        public string Religion { get; set; }

       // [Required(ErrorMessage = "Select Your Blood Group.")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Select Your Country.")]
        public string Nationality { get; set; }

       // [Required(ErrorMessage = "Select Registration Date.")]
        public DateTime? RegDateTime { get; set; }

        public DateTime? LastLoginDateTime { get; set; }


    }
}