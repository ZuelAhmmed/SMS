using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public partial class RoomInformation
    {
        public RoomInformation()
        {
            this.ScheduleInformations = new HashSet<ScheduleInformation>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long RmRoomId { get; set; }
        public string RmRoomNo { get; set; }
        public string RmFloorNo { get; set; }
        public int? RmCapacity { get; set; }
        public string RmDescription { get; set; }
        public long? RmCampus { get; set; }
        //public string Department { get; set; }
        //[ForeignKey("Department")]
        //public virtual Department DepartmentTDepartment { get; set; }
        //[ForeignKey("RMCampus")]
        //public virtual Campus Campus { get; set; }

        public virtual ICollection<ScheduleInformation> ScheduleInformations { get; set; }
    }
}