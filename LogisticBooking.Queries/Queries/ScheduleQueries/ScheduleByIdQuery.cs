using System;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.Queries.ScheduleQueries
{
    public class ScheduleByIdQuery : Query<Schedule>
    {
        public Guid ScheduleId { get; set; }
        
        public ScheduleByIdQuery(Guid id)
        {
            ScheduleId = id;
        }
    }
}