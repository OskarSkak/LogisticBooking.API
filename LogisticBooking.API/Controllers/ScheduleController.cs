using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticBooking.API.RequestModels;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands.ScheduleCommands;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries;
using LogisticBooking.Queries.Queries.Booking;
using LogisticBooking.Queries.Queries.ScheduleQueries;
using Microsoft.AspNetCore.Mvc;

namespace LogisticBooking.API.Controllers
{
    
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : BaseController
    {
        public ScheduleController(ICommandRouter commandRouter, IQueryRouter queryRouter): base(commandRouter,
            queryRouter)
        {
            
            
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewSchedule([FromBody] ScheduleRequesteModel scheduleRequesteModel)
        {
            var result = await CommandRouter.RouteAsync<CreateScheduleCommand, IdResponse>(
                new CreateScheduleCommand(scheduleRequesteModel.ScheduleDay, scheduleRequesteModel.CreatedBy,
                    scheduleRequesteModel.MischellaneousPallets, scheduleRequesteModel.shifts, scheduleRequesteModel.Intervals, scheduleRequesteModel.ScheduleId
                    , scheduleRequesteModel.Name));

            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {

            var result = await QueryRouter.QueryAsync<SchedulesQuery, List<Schedule>>(new SchedulesQuery());

            if (result == null)
            {
                return new ObjectResult(IdResponse.Unsuccessful(""));
            }
            
            return new ObjectResult(result);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetScheduleById(Guid id)
        {

            var result = await QueryRouter.QueryAsync<ScheduleByIdQuery, Schedule>(new ScheduleByIdQuery(id));
            
            return new ObjectResult(result);
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> InsertManySchedules(
            [FromBody] ManySchedulesRequestModels scheduleRequesteModels)
        {
        
            List<Schedule> list = new List<Schedule>();
            foreach (var VARIABLE in scheduleRequesteModels.Schedules)
            {
                list.Add(new Schedule
                {
                    CreatedBy = VARIABLE.CreatedBy,
                    Intervals = VARIABLE.Intervals,
                    MischellaneousPallets = VARIABLE.MischellaneousPallets,
                    Name = VARIABLE.Name,
                    ScheduleDay = VARIABLE.ScheduleDay,
                    ScheduleId = VARIABLE.ScheduleId
                    
                });
            }

            var result =
                await CommandRouter.RouteAsync<InserManySchedulesCommand, IdResponse>(
                    new InserManySchedulesCommand(list));
            
            return new ObjectResult(result);
        }
        
        
    }
}