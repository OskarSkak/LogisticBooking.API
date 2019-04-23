using System;
using SimpleSoft.Mediator;

namespace LogisticBooking.Events.Events
{
    public class TransporterDeletedEvent : IEvent
    {
        public Guid TransporterId { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}