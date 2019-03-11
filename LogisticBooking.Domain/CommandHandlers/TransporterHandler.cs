using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Events.Events;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class TransporterHandler : ICommandHandler<CreateTransporterCommand, IdResponse>, ICommandHandler<UpdateTransporterCommand, IdResponse>
    {
        private readonly ITransporterRepository _transporterRepository;
        private readonly IEventRouter _eventRouter;

        public TransporterHandler(ITransporterRepository transporterRepository, IEventRouter eventRouter)
        {
            _transporterRepository = transporterRepository;
            _eventRouter = eventRouter;
        }

        public async Task<IdResponse> HandleAsync(CreateTransporterCommand cmd, CancellationToken ct)
        {
            
            var result = await _transporterRepository.InsertAsync(new Transporter
            {
                ID = cmd.ID,
                Name = cmd.Name,
                Telephone = cmd.Telephone,
                Address = cmd.Address,
                Email = cmd.Email
            });

            var transporter = new TransporterCreatedEvent();
            transporter.Email = cmd.Email;
            _eventRouter.EventAsync(transporter);

            return new IdResponse(cmd.ID); 
        }

        public async Task<IdResponse> HandleAsync(UpdateTransporterCommand cmd, CancellationToken ct)
        {
            var result = await _transporterRepository.UpdateAsync(new Transporter
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
