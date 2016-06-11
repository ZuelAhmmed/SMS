using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class ConfirmationCatagory
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

    }

    
}