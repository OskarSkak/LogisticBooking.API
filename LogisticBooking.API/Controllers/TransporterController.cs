using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticBooking.API.RequestModels;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries;
using Microsoft.AspNetCore.Authorization;
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

        //Needs to check for empties or nulls, fix after GetById is implemented!
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTransporter(Guid id, [FromBody] TransporterRequestModel transporterRequestModel)
        {
            var Transporter = await QueryRouter.QueryAsync<GetTransporterById, Transporter>(new GetTransporterById(id));
            if(Transporter != null)
            {
                if (String.IsNullOrEmpty(transporterRequestModel.Name))
                    transporterRequestModel.Name = Transporter.Name;
                if (String.IsNullOrEmpty(transporterRequestModel.Address))
                    transporterRequestModel.Address = Transporter.Address;
                if (transporterRequestModel.Telephone == 0)
                    transporterRequestModel.Telephone = Transporter.Telephone;
                if (String.IsNullOrEmpty(transporterRequestModel.Email))
                    transporterRequestModel.Email = Transporter.Email;
            }

            var result = await CommandRouter.RouteAsync<UpdateTransporterCommand, IdResponse>(
                new UpdateTransporterCommand(transporterRequestModel.Email, transporterRequestModel.Telephone, 
                transporterRequestModel.Address, transporterRequestModel.Name, id)
                );
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetTransporters()
        {
            //var CurrentUser = User.Claims.FirstOrDefault((c => c.Type == "sub")).Value;

           // Console.WriteLine(CurrentUser);
        
            var result = await QueryRouter.QueryAsync<TransportersQuery, IList<Transporter>>(new TransportersQuery());

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBydId(Guid id)
        {
            var result = await QueryRouter.QueryAsync<GetTransporterById, Transporter>(new GetTransporterById(id));
            return new ObjectResult(result);
        }

    }
}
