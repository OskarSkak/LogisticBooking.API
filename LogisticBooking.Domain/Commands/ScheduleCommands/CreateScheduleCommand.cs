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
        
        public CreateScheduleCommand(DateTime scheduleDay , Guid createdBy , int mischellaneousPallets , Shift shift)
        {
            ScheduleDay = scheduleDay;
            CreatedBy = createdBy;
            MischellaneousPallets = mischellaneousPallets;
            Shifts = shift;
        }
    }
}