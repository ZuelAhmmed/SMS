using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class CommitteeCatagory
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Type Committee Name")]
        public string Name { get; set; }

        [DisplayName("Member Number")]
        [Required(ErrorMessage = "Type How Much Member will Have")]
        public string MemberNo { get; set; }

        [DisplayName("Short Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select Established Date.")]
        public DateTime Established { get; set; }

        public virtual ICollection<CommitteeDesignation> CommitteeDesignations { get; set; }
    }

    public class CommitteeDesignation
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Designation")]
        [Required(ErrorMessage = "Type Designation Name")]
        public string Name { get; set; }

        [DisplayName("Committee Name")]
        [Required(ErrorMessage = "Select Committee Name")]
        public int CommitteeCatagoryId { get; set; }

        [DisplayName("Member Number")]
        [Required(ErrorMessage = "Type Number of Member")]
        public string MemberNo { get; set; }

        [DisplayName("Small Description")]
        public string Description { get; set; }


        [ForeignKey("CommitteeCatagoryId")]
        public virtual CommitteeCatagory CommitteeCatagory { get; set; }

    }

    public class CommitteeMembers
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Member Name")]
        [Required(ErrorMessage = "Select Member Name")]
        public int NidOrBirthRegNo { get; set; }
        
        [Required(ErrorMessage = "Select Committee")]
        public int CommitteeCatagoryId { get; set; }

        [Required(ErrorMessage = "Select Designation")]
        public int CommitteeDesignationId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AppointedDate { get; set; }
    }
}