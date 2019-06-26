using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.QueryHandler
{
    public class TransporterQueryHandler : IQueryHandler<TransportersQuery, IList<Transporter>>, IQueryHandler<GetTransporterById, Transporter>
    {
        private readonly ITransporterRepository _transporterRepository;

        public TransporterQueryHandler(ITransporterRepository transporterRepository)
        {
            _transporterRepository = transporterRepository;
        }

        public async Task<IList<Transporter>> HandleAsync(TransportersQuery query, CancellationToken ct)
        {
            var result = _transporterRepository.GetAll();
            return result.ToList();
        }

        public async Task<Transporter> HandleAsync(GetTransporterById query, CancellationToken ct)
        {
            var result = _transporterRepository.GetById(query.Id);
            return result;
        }
    }
}
