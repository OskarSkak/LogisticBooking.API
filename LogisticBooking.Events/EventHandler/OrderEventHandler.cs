

using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Events.Events;
using SimpleSoft.Mediator;

namespace LogisticBooking.Events.EventHandler
{
    public class OrderEventHandler : IEventHandler<OrderCreatedEvent>
    {
        public async Task HandleAsync(OrderCreatedEvent evt, CancellationToken ct)
        {
            Console.WriteLine("Event Order is created");
        }
    }
}