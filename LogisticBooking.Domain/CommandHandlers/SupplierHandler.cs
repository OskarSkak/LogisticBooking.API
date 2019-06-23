using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;

using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;

using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class SupplierHandler : ICommandHandler<CreateSupplierCommand, IdResponse>, ICommandHandler<DeleteSupplierCommand, IdResponse>, 
        ICommandHandler<UpdateSupplierCommand, IdResponse>
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
            var result = _supplierRepository.Insert(new Supplier
            {
                ID = cmd.ID,
                Name = cmd.Name,
                Telephone = cmd.Telephone,
                Email = cmd.Email
            });

            return new IdResponse(cmd.ID);
        }
        
        public async Task<IdResponse> HandleAsync(DeleteSupplierCommand cmd, CancellationToken ct)
        {
            if (cmd.Id.Equals(Guid.Empty))
            {
                return IdResponse.Unsuccessful("Id is empty");
            }

            var supplier =  _supplierRepository.GetById(cmd.id);

            var result =  _supplierRepository.DeleteByT(supplier);
            
            return new IdResponse(cmd.Id);
        }

        public async Task<IdResponse> HandleAsync(UpdateSupplierCommand cmd, CancellationToken ct)
        {
            var result = _supplierRepository.Update(new Supplier
            {
                Name = cmd.Name,
                Email = cmd.Email,
                Telephone = cmd.Telephone, 
                ID = cmd.id
                
            });
            return new IdResponse(cmd.Id);
        }
    }
}
