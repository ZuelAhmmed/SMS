using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SMS.Models
{
    public class AddressViewModel
    {
        public string Code { get; set; }

        [Required(ErrorMessage = "Address Catagory Needed.")]
        public string Catagory { get; set; }

        [Required(ErrorMessage = "Select/Type Username")]
        public string UserName { get; set; }

        public string NidOrBirtgRegNo { get; set; }

        [Required(ErrorMessage = "Type Your Holding/Block/Sector")]
        public string HoldingBlockSector { get; set; }

        [Required(ErrorMessage = "Select Your Division")]
        public string Division { get; set; }

        [Required(ErrorMessage = "Select Your District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Select Your RMO")]
        public string Rmo { get; set; }

        [Required(ErrorMessage = "Select Your Police Station")]
        public string PoliceStation { get; set; }

        [Required(ErrorMessage = "Select Your Union/Word")]
        public string UnionOrWord { get; set; }

        [Required(ErrorMessage = "Select Your Post Office")]
        public string PostOffice { get; set; }

        [Required(ErrorMessage = "Select Your Village")]
        public string Village { get; set; }
    }

    public class AddressCatagory
    {
        [Key]
        public string Code { get; set; }
         
        public string Name { get; set; }
    }

    public class Address
    {
        [Key]
        public string Code { get; set; }
        
        [DisplayName("Username")]
        public string NidOrBirthRegNo { get; set; }
        
        [DisplayName("Address Catagory")]
        [Required(ErrorMessage = "Please Select Address Catagory.")]
        public string AddressCatagory { get; set; } 

        [Required(ErrorMessage = "Address Not Found Correctly")]
        public string AddressRefCode { get; set; }

        [DisplayName("Holding/Block/Sector")]
        [Required(ErrorMessage = "Type Holding/Block/Sector")]
        public string HoldingBlockSector { get; set; }

    }

    public class Country
    {
        [Key]
        public string Code { get; set; }

        [DisplayName("Country Name")]
        [Required(ErrorMessage = "Type Country Name.")]
        public string Name { get; set; }

        [DisplayName("Country Code")]
        [Required(ErrorMessage = "Type Country Code")]
        public string MobileCode { get; set; }
    }

    public class Division
    {
        [Key]
        [StringLength(1, ErrorMessage = "You Can Input Only One Digit")]
        [Required(ErrorMessage = "Type Division Code.")]
        public string Code { get; set; }

        [DisplayName("Division Name")]
        [Required(ErrorMessage = "Type Division Name.")]
        public string Name { get; set; }


        public virtual ICollection<District> Districts { get; set; }
    }

    public class District
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "You Can Input Only Two Digit")]
        [Required(ErrorMessage = "Type District Code")]
        public string Code { get; set; }

        [DisplayName("District Name")]
        [Required(ErrorMessage = "Type District Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Divosion")]
        public string DivisionId { get; set; }

        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }

        public virtual ICollection<PoliceStation> PoliceStations { get; set; }
    }

    public class Rmo
    {
        [Key]
        [StringLength(1, ErrorMessage = "You Can Input Only One Digit")]
        [Required(ErrorMessage = "Type RMO Code")]
        public string Id { get; set; }

        [DisplayName("RMO Name")]
        [Required(ErrorMessage = "Type RMO Name")]
        public string Name { get; set; }
    }


    public class PoliceStation
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "You Can Input Only Two Digit")]
        [Required(ErrorMessage = "Type Police Station Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Type Police Station Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select District.")]
        public string DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        public virtual ICollection<UnionOrWord> UnionOrWords { get; set; }
        public virtual ICollection<PostOffice> PostOffices { get; set; }
    }

    public class UnionOrWord
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "You Can Input Only Two Digit")]
        [Required(ErrorMessage = "Type Union/Word Code")]
        public string Code { get; set; } 

        [DisplayName("Name")]
        [Required(ErrorMessage = "Type Union/Word Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Police Station")]
        public string PoliceStationId { get; set; }

        [ForeignKey("PoliceStationId")]
        public virtual PoliceStation PoliceStation { get; set; }
    }

    public class PostOffice
    {
        [Key]
        public string Code { get; set; }

        [DisplayName("Post Code")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "You Can Input Only Four Digit")]
        [Required(ErrorMessage = "Type Post Code")]
        public string PostCode { get; set; } 

        [DisplayName("Post Name")]
        [Required(ErrorMessage = "Type Post Office Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Police Station")]
        public string PoliceStationId { get; set; }

        [ForeignKey("PoliceStationId")]
        public virtual PoliceStation PoliceStation { get; set; }

        public virtual ICollection<VillageRoad> VillageOrRoads { get; set; }
    }

    public class VillageRoad
    {
        [Key]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "You Can Input Only One Digit")]
        [Required(ErrorMessage = "Type Village Code.")]
        public string Code { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Type Village/Road Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Police Station.")]
        public string PostOfficeId { get; set; }

        [ForeignKey("PostOfficeId")]
        public virtual PostOffice PostOffice { get; set; }
    }
}