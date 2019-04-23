using System;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.Queries.Booking
{
    public class GetBookingById : Query<Persistence.Models.Booking>
    {
        public Guid id { get; set; }

        public GetBookingById(Guid id)
        {
            this.id = id;
        }
    }
}