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
    
    [Route("api/orders")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(ICommandRouter commandRouter, IQueryRouter queryRouter): base(commandRouter,
            queryRouter)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOrder([FromBody] OrderRequestModel orderRequestModel)
        {
            var result = await
                CommandRouter.RouteAsync<CreateOrderCommand, IdResponse>(
                    new CreateOrderCommand(orderRequestModel.OrderName));
            
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await QueryRouter.QueryAsync<OrdersQuery , IList<Order>> (new OrdersQuery());
            
            return new ObjectResult(result);
        }
    }
}