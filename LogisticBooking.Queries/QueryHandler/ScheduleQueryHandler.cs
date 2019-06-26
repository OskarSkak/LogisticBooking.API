using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries.ScheduleQueries;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.QueryHandler
{
    public class ScheduleQueryHandler : IQueryHandler<SchedulesQuery , List<Schedule>> , IQueryHandler<ScheduleByIdQuery , Schedule>
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleQueryHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        
        
        public async Task<List<Schedule>> HandleAsync(SchedulesQuery query, CancellationToken ct)
        {
            return _scheduleRepository.GetAll();
        }

        public async Task<Schedule> HandleAsync(ScheduleByIdQuery query, CancellationToken ct)
        {
            return _scheduleRepository.GetById(query.ScheduleId);
        }
    }
}