using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using LogisticBooking.Queries.Queries;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.QueryHandler
{
    public class SupplierQueryHandler : IQueryHandler<SuppliersQuery, IList<Supplier>>, IQueryHandler<GetSupplierById, Supplier>
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        
        public async Task<IList<Supplier>> HandleAsync(SuppliersQuery query, CancellationToken ct)
        {
            var result = await _supplierRepository.GetAllAsync();
            
            return result.ToList();
        }

        public async Task<Supplier> HandleAsync(GetSupplierById query, CancellationToken ct)
        {
            var result = await _supplierRepository.GetByIdAsync(query.id);
            return result;
        }
    }
}