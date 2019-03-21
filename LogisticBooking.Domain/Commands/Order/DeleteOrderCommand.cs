using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.Order
{
    public class DeleteOrderCommand : Command<IdResponse>
    {
        public Guid id { get; set; }

        public DeleteOrderCommand(Guid id)
        {
            this.id = id;
        }
    }
}