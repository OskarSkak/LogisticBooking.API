using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticBooking.API.RequestModels;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LogisticBooking.API.Controllers
{
    [Route ("api/transporters")]
    [ApiController]
    public class TransporterController : BaseController
    {
        public TransporterController(ICommandRouter commandRouter, IQueryRouter queryRouter) : 
            base(commandRouter, queryRouter)
        {}

        [HttpPost]
        public async Task<IActionResult> CreateNewTransporter([FromBody] TransporterRequestModel transporterRequestModel)
        {
            var result = await CommandRouter.RouteAsync<CreateTransporterCommand, IdResponse>(
                new CreateTransporterCommand(transporterRequestModel.Email,
                transporterRequestModel.Telephone, transporterRequestModel.Address, 
                transporterRequestModel.Name));

            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

    }
}
