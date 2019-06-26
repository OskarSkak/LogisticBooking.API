using System;
using System.Collections.Generic;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.ScheduleCommands
{
    public class CreateScheduleCommand : Command<IdResponse>
    {
        

        public DateTime ScheduleDay { get; set; }
        public Guid CreatedBy { get; set; }
        public int MischellaneousPallets { get; set; }
        public Shift Shifts { get; set; }
        public List<Interval> Intervals { get; set; }
        public Guid ScheduleId { get; set; }
        public string Name { get; set; }
        
        public CreateScheduleCommand(DateTime scheduleDay , Guid createdBy , int mischellaneousPallets , Shift shift, List<Interval> intervals, Guid scheduleId, string name)
        {
            ScheduleDay = scheduleDay;
            CreatedBy = createdBy;
            MischellaneousPallets = mischellaneousPallets;
            Shifts = shift;
            Intervals = intervals;
            ScheduleId = scheduleId;
            Name = name;
        }
    }
}