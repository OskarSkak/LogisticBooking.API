using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.Order
{
    public class UpdateOrderCommand : Command<IdResponse>
    {
        public UpdateOrderCommand(Guid bookingId, string customerNumber, string orderNumber, int wareNumber, string inOut, Guid id , string supplierNamer , string externalId, int totalPallets , int bottomPallets , string comment)
        {
            this.bookingId = bookingId;
            this.customerNumber = customerNumber;
            this.orderNumber = orderNumber;
            this.wareNumber = wareNumber;
            InOut = inOut;
            this.id = id;
            SupplierName = supplierNamer;
            ExternalId = externalId;
            TotalPallets = totalPallets;
            BottomPallets = bottomPallets;
            Comment = comment;
        }
        public Guid bookingId { get; set; }
        public string customerNumber { get; set; }
        public string orderNumber { get; set; }
        public int wareNumber { get; set; }
        public string InOut { get; set; }
        public Guid id { get; set; }
        public string SupplierName { get; set; }
        public string ExternalId { get; set; }
        public int TotalPallets { get; set; }
        public int BottomPallets { get; set; }
        public string Comment { get; set; }
    }
}