using System;
   using System.Threading;
   using System.Threading.Tasks;
   using LogisticBooking.Events.Events;
   using SimpleSoft.Mediator;
   
   namespace LogisticBooking.Events.EventHandler
   {
       public class EmailEvent : IEventHandler<OrderCreatedEvent>
       {
           public async Task HandleAsync(OrderCreatedEvent evt, CancellationToken ct)
           {
               Console.WriteLine("Event received Sending email");
           }
       }
   }