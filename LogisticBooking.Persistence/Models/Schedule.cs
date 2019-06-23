using System;
using System.Collections.Generic;

namespace LogisticBooking.Persistence.Models
{
    public class Schedule
    {
        public List<Interval> Intervals { get; set; }
        public DateTime ScheduleDay { get; set; }
        public Guid CreatedBy { get; set; }
        public int MischellaneousPallets { get; set; }
        public enum Shift
        {
            Day, Night
        }
        public Guid Id { get; }
    }
}