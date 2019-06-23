using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticBooking.Persistence.Models
{
    public enum Shift
    {
        Day,Night
    }
    
    public class Schedule
    {
        public List<Interval> Intervals { get; set; }
        public DateTime ScheduleDay { get; set; }
        public Guid CreatedBy { get; set; }
        public int MischellaneousPallets { get; set; }
        public Shift shifts { get; set; }
        
        [Key]
        public Guid ScheduleId { get; set; }
    }
}