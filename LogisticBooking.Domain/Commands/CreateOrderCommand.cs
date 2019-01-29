using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands
{
    public class CreateOrderCommand : Command<IdResponse>
    {
        public string OrderName { get; set; }

        public CreateOrderCommand(string orderName)
        {
            OrderName = orderName;

        }
    }
}