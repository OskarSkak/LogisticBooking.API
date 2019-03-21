using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.Order
{
    public class UpdateOrderCommand : Command<IdResponse>
    {
        public UpdateOrderCommand(Guid bookingId, string customerNumber, string orderNumber, int wareNumber, string inOut, Guid id)
        {
            this.bookingId = bookingId;
            this.customerNumber = customerNumber;
            this.orderNumber = orderNumber;
            this.wareNumber = wareNumber;
            InOut = inOut;
            this.id = id;
        }
        public Guid bookingId { get; set; }
        public string customerNumber { get; set; }
        public string orderNumber { get; set; }
        public int wareNumber { get; set; }
        public string InOut { get; set; }
        public Guid id { get; set; }
    }
}