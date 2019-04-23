using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.Booking
{
    public class DeleteBookingCommand : Command<IdResponse>
    {
        public Guid id { get; set; }

        public DeleteBookingCommand(Guid id)
        {
            this.id = id;
        }
    }
}