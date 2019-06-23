using System.Threading.Tasks;
using LogisticBooking.API.RequestModels;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands.ScheduleCommands;
using LogisticBooking.Infrastructure.MessagingContracts;
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
                    scheduleRequesteModel.MischellaneousPallets, scheduleRequesteModel.shifts));

            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }
        
        
    }
}