using System;
using System.Runtime.InteropServices;
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
    public class TransporterHandler : ICommandHandler<CreateTransporterCommand, IdResponse>, ICommandHandler<UpdateTransporterCommand, IdResponse>, 
        ICommandHandler<DeleteTransporterCommand, IdResponse>
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly ITransporterRepository _transporterRepository;
        private readonly IEventRouter _eventRouter;

        public TransporterHandler(ITransporterRepository transporterRepository, IEventRouter eventRouter , IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            _transporterRepository = transporterRepository;
            _eventRouter = eventRouter;
        }

        public async Task<IdResponse> HandleAsync(DeleteTransporterCommand cmd, CancellationToken ct)
        {
            if (cmd.Id.Equals(Guid.Empty))
            {
                return IdResponse.Unsuccessful("Id is empty");
            }

            var transporter = await _transporterRepository.GetByIdAsync(cmd.id);

            var result = await _transporterRepository.DeleteByTAsync(transporter);
            
            return new IdResponse(cmd.Id);
        }

        public async Task<IdResponse> HandleAsync(CreateTransporterCommand cmd, CancellationToken ct)
        {
            var guid = Guid.NewGuid();
            // Create the transporter in the backend database
            var BackendResult = await _transporterRepository.InsertAsync(new Transporter
            {
                ID = guid,
                Name = cmd.Name,
                Telephone = cmd.Telephone,
                Address = cmd.Address,
                Email = cmd.Email
            });

            if (BackendResult == null)
            {
                //#TODO  Spørg oskar hvad vi skal her? skal vi throwe exceprtion?
                return null;
            }

            await _registrationRepository.InsertAsync(new RegistrationKey
            {
                Username = cmd.Email,
                SubjectId = guid.ToString(),
                IsActive = false
            });

            
            
            var transporter = new TransporterCreatedEvent();
            transporter.Email = cmd.Email;
            transporter.Id = guid;
            _eventRouter.EventAsync(transporter);

            return new IdResponse(guid); 
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
