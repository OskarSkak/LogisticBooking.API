using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using LogisticBooking.Queries.Queries.Util;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.QueryHandler
{
    public class UtilBookingHandler : IQueryHandler<UtilBookingQuery , Persistence.Models.UtilBooking>
    {
        private readonly IUtilBookingRepository _utilBookingRepository;

        public UtilBookingHandler(IUtilBookingRepository utilBookingRepository)
        {
            _utilBookingRepository = utilBookingRepository;
        }


        public async Task<UtilBooking> HandleAsync(UtilBookingQuery query, CancellationToken ct)
        {
            var result = await _utilBookingRepository.GetAllAsync();
            var booking = result.First();
            return booking;
        }
    }
}