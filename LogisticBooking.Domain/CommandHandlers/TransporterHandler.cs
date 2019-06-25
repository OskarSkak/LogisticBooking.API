using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.API;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Events.Events;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class TransporterHandler : ICommandHandler<CreateTransporterCommand, IdResponse>, ICommandHandler<UpdateTransporterCommand, IdResponse>, 
        ICommandHandler<DeleteTransporterCommand, IdResponse>
    {
        private readonly ITransporterRepository _transporterRepository;
        private readonly IEventRouter _eventRouter;
        private readonly testContext _context;

        public TransporterHandler(ITransporterRepository transporterRepository, IEventRouter eventRouter , testContext context)
        {
            
            _transporterRepository = transporterRepository;
            _eventRouter = eventRouter;
            _context = context;
        }

        public async Task<IdResponse> HandleAsync(DeleteTransporterCommand cmd, CancellationToken ct)
        {
            if (cmd.Id.Equals(Guid.Empty))
            {
                return IdResponse.Unsuccessful("Id is empty");
            }

            var transporter = _transporterRepository.GetById(cmd.id);

            var result = _transporterRepository.DeleteByT(transporter);

            var user = _context.Users.Find(cmd.id.ToString());
            _context.Users.Remove(user);
            _context.SaveChanges();
            var transporterDeletedEvent = new TransporterDeletedEvent
            {
                TransporterId = cmd.id
            };
            _eventRouter.EventAsync(transporterDeletedEvent);
            
            return new IdResponse(cmd.Id);
        }

        public async Task<IdResponse> HandleAsync(CreateTransporterCommand cmd, CancellationToken ct)
        {
            var guid = Guid.NewGuid();
            // Create the transporter in the backend database
            var BackendResult = _transporterRepository.Insert(new Transporter
            {
                ID = guid,
                Name = cmd.Name,
                Telephone = cmd.Telephone,
                Address = cmd.Address,
                Email = cmd.Email
            });
            
            var user = new Users();
            user.Username = cmd.Email;
            user.IsActive = false;
            user.SubjectId = guid.ToString();


            _context.Users.Add(user);
            _context.SaveChanges();
            // Create the transporter in Identioty
            var transporter = new TransporterCreatedEvent();
            transporter.Email = cmd.Email;
            transporter.Id = guid;
            _eventRouter.EventAsync(transporter);

            return new IdResponse(guid); 
        }

        public async Task<IdResponse> HandleAsync(UpdateTransporterCommand cmd, CancellationToken ct)
        {
            var result = _transporterRepository.Update(new Transporter
            {
                Name = cmd.Name, 
                Telephone = cmd.Telephone, 
                Address = cmd.Address, 
                Email = cmd.Email,
                ID = cmd.id
            });
            return new IdResponse(cmd.Id); 
        }
    }
}
