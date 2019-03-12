using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticBooking.Domain.Commands
{
    public class CreateSupplierCommand : Command<IdResponse>
    {
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Name { get; set; }
        public Guid ID { get; set; }

        public CreateSupplierCommand(string email, int telephone, string name)
        {
            Email = email;
            Telephone = telephone;
            Name = name;
            ID = Guid.NewGuid();
        }
    }
}
