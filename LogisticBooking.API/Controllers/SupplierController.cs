using System;
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

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var result = await QueryRouter.QueryAsync<SuppliersQuery, IList<Supplier>>(new SuppliersQuery());
            return new ObjectResult(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSupplier(Guid id, [FromBody] SupplierRequestModel supplierRequestModel)
        {
            //var supplier = await QueryRouter
            return null;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await QueryRouter.QueryAsync<GetSupplierById, Supplier>(new GetSupplierById(id));
            return new ObjectResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleterSupplier(Guid id)
        {
            var result =
                await CommandRouter.RouteAsync<DeleteSupplierCommand, IdResponse>(new DeleteSupplierCommand(id));
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }
        
        
    }
}
