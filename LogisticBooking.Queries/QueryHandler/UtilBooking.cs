
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
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
            
            var result =  _utilBookingRepository.GetUtilBooking();
            
            return result;
        }
    }
}