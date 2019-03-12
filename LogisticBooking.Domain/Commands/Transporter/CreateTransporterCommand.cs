using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticBooking.Domain.Commands
{
    public class CreateTransporterCommand : Command<IdResponse>
    {
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public Guid ID { get; set; }

        public CreateTransporterCommand(string email, int telephone, string address, string name)
        {
            Email = email;
            Telephone = telephone;
            Address = address;
            Name = name;
            ID = Guid.NewGuid(); 
        }
    }
}
