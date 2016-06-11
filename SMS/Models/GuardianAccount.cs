using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class GuardianAccount : BasicAccount
    {
        [DisplayName("Yearly Family Income")]
        [Required(ErrorMessage = "Type Family Income")]
        public string FamilyIncome { get; set; }
    }
}