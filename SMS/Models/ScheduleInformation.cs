using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public partial class ScheduleInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ShScheduleId { get; set; }
        public long RmRoomId { get; set; }
        public string ShClass { get; set; }
        public string ShDay { get; set; }
        public DateTime? ShFromTime { get; set; }
        public DateTime? ShToTime { get; set; }
        public string ShCourse { get; set; }
        public string ShSection { get; set; }

        [ForeignKey("RmRoomId")]
        public virtual RoomInformation RoomInformation { get; set; }
    }
}