using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands.ScheduleCommands;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class ScheduleHandler : ICommandHandler<CreateScheduleCommand , IdResponse>
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<IdResponse> HandleAsync(CreateScheduleCommand cmd, CancellationToken ct)
        {
            _scheduleRepository.Insert(new Schedule(
            {
                shifts = cmd.Shifts,
                CreatedBy = cmd.CreatedBy,
                Intervals = new List<Interval>(),
                MischellaneousPallets = cmd.MischellaneousPallets,
                ScheduleId = Guid.NewGuid(),
                ScheduleDay = cmd.ScheduleDay
            });
            
            
        }
    }
}