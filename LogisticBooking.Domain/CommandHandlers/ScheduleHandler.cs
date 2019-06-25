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

        public async Task<IdResponse> HandleAsync(CreateScheduleCommand cmd, CancellationToken ct)
        {
            var id = Guid.NewGuid();
            if (cmd.ScheduleId != Guid.Empty) id = cmd.ScheduleId;
            
            var result = _scheduleRepository.Insert(new Schedule
            {
                shifts = cmd.Shifts,
                CreatedBy = cmd.CreatedBy,
                Intervals = cmd.Intervals,
                MischellaneousPallets = cmd.MischellaneousPallets,
                ScheduleId = id,
                ScheduleDay = cmd.ScheduleDay
            });
            
            return new IdResponse(id);
        }
    }
}