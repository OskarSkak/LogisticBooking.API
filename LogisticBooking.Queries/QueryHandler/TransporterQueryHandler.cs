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
    public class TransporterQueryHandler : IQueryHandler<TransportersQuery, IList<Transporter>>
    {
        private readonly ITransporterRepository _transporterRepository;

        public TransporterQueryHandler(ITransporterRepository transporterRepository)
        {
            _transporterRepository = transporterRepository;
        }

        public async Task<IList<Transporter>> HandleAsync(TransportersQuery query, CancellationToken ct)
        {
            var result = await _transporterRepository.GetAllAsync();
            return result.ToList();
        }
    }
}
