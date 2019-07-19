using System;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.Queries.ScheduleQueries
{
    public class ScheduleByDateQuery : Query<Schedule>
    {
        public DateTime Date { get; set; }

        public ScheduleByDateQuery(DateTime date)
        {
            Date = date;
        }
    }
}