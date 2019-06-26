using System;
using System.Collections.Generic;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.API.RequestModels
{
    public class ScheduleRequesteModel
    {
        public DateTime ScheduleDay { get; set; }
        public Guid CreatedBy { get; set; }
        public int MischellaneousPallets { get; set; }
        public Shift shifts { get; set; }
        public List<Interval> Intervals { get; set; }
        public string Name { get; set; }
        public Guid ScheduleId { get; set; }
    }
}