using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class StartupGeneralInfo
    {
        [Key]
        public int EiinNumber { get; set; }
        public string NameInBengali { get; set; }
        public string NameInEnglish { get; set; }
        public Address InstituteAddress { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteAddress { get; set; }
        public string MpoCodeNumber { get; set; }
    }


}