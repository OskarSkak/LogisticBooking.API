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
    public class SupplierHandler : ICommandHandler<CreateSupplierCommand, IdResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IEventRouter _eventRouter;

        public SupplierHandler(ISupplierRepository supplierRepository, IEventRouter eventRouter)
        {
            _supplierRepository = supplierRepository;
            _eventRouter = eventRouter;
        }

        public async Task<IdResponse> HandleAsync(CreateSupplierCommand cmd, CancellationToken ct)
        {
            var result = await _supplierRepository.InsertAsync(new Supplier
            {
                ID = cmd.ID,
                Name = cmd.Name,
                Telephone = cmd.Telephone,
                Email = cmd.Email
            });

            return new IdResponse(cmd.ID);
        }
    }
}
