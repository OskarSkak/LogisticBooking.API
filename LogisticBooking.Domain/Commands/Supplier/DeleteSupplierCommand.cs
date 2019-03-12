using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands
{
    public class DeleteSupplierCommand : Command<IdResponse>
    {
        public Guid id { get; set; }

        public DeleteSupplierCommand(Guid id)
        {
            this.id = id;
        }
    }
}