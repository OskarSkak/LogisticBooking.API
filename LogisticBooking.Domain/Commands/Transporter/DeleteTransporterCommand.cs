using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands
{
    public class DeleteTransporterCommand : Command<IdResponse>
    {
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public Guid id { get; set; }
        
        
        public DeleteTransporterCommand(Guid _id)
        {
            id = _id;
        }
    }
}