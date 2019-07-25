using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands
{
    public class UpdateSupplierCommand : Command<IdResponse>
    {
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Name { get; set; }
        public Guid id { get; set; }
        public DateTime DeliveryStart { get; set; }
        public DateTime DeliveryEnd { get; set; }

        public UpdateSupplierCommand(string email, int telephone, string name, Guid id , DateTime DeliveryStart , DateTime DeliveryEnd)
        {
            Email = email;
            Telephone = telephone;
            Name = name;
            this.id = id;
            this.DeliveryStart = DeliveryStart;
            this.DeliveryEnd = DeliveryEnd;
        }
    }
}