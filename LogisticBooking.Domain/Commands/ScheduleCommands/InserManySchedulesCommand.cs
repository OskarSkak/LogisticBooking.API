using System.Collections.Generic;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.ScheduleCommands
{
    public class InserManySchedulesCommand : Command<IdResponse>
    {
        public List<Schedule> Schedules { get; set; }
        
        public InserManySchedulesCommand(List<Schedule> schedules)
        {
            Schedules = schedules;
        }
    }
}