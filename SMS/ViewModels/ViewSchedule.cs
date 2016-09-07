using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.ViewModels
{
    public class ViewSchedule
    {
        public SelectList ClassId { get; set; }
        public IEnumerable<RoomInformation> RoomInformation { get; set; }
        public ScheduleInformation ScheduleInfo { get; set; }
        //public IEnumerable<ScheduleInformation> ScheduleInformation { get; set; }
        public List<ViewScheduleInformation> ScheduleInformation { get; set; }



    }
}