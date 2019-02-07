using System;
using SimpleSoft.Mediator;

namespace LogisticBooking.Events.Events
{
    public class TransporterCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}