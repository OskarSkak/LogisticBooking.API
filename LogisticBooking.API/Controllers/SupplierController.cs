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
    [Route ("api/suppliers")]
    [ApiController]
    public class SupplierController : BaseController
    {
        public SupplierController(ICommandRouter commandRouter, IQueryRouter queryRouter) :
            base(commandRouter, queryRouter)
        { }

        [HttpPost]
        public async Task<IActionResult> CreateNewSupplier([FromBody] SupplierRequestModel supplierRequestModel)
        {
            var result = await CommandRouter.RouteAsync<CreateSupplierCommand, IdResponse>(
                new CreateSupplierCommand(supplierRequestModel.Email,
                supplierRequestModel.Telephone, supplierRequestModel.Name));

            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }
    }
}
