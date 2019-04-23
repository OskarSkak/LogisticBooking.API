using System;
using SimpleSoft.Mediator;

namespace LogisticBooking.Events.Events
{
    public class OrderCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}