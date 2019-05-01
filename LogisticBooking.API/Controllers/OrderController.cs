using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticBooking.API.Controllers;
using LogisticBooking.API.RequestModels;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Domain.Commands.Order;
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
            var result = await CommandRouter.RouteAsync<CreateOrderCommand, IdResponse>(
                new CreateOrderCommand(orderRequestModel.bookingId, orderRequestModel.customerNumber, 
                    orderRequestModel.orderNumber, orderRequestModel.wareNumber, orderRequestModel.InOut));
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await QueryRouter.QueryAsync<OrdersQuery , IList<Order>> (new OrdersQuery());
            
            return new ObjectResult(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderRequestModel orderRequestModel)
        {
            var order = await QueryRouter.QueryAsync<GetOrderById, Order>(new GetOrderById(id));

            if (order != null)
            {
                if (String.IsNullOrEmpty(orderRequestModel.customerNumber))
                    orderRequestModel.customerNumber = order.customerNumber;
                if (String.IsNullOrEmpty(orderRequestModel.orderNumber))
                    orderRequestModel.orderNumber = order.orderNumber;
                if (String.IsNullOrEmpty(orderRequestModel.InOut))
                    orderRequestModel.InOut = order.InOut;
                if (orderRequestModel.bookingId == Guid.Empty)
                    orderRequestModel.bookingId = order.bookingId;
                if (orderRequestModel.wareNumber == 0)
                    orderRequestModel.wareNumber = order.wareNumber;
                if (String.IsNullOrEmpty(orderRequestModel.ExternalId))
                    orderRequestModel.ExternalId = order.ExternalId;
                if (String.IsNullOrEmpty(orderRequestModel.Comment))
                    orderRequestModel.Comment = order.Comment;
                if (String.IsNullOrEmpty(orderRequestModel.SupplierName))
                    orderRequestModel.SupplierName = order.SupplierName;
                
            }

            var result = await CommandRouter.RouteAsync<UpdateOrderCommand, IdResponse>(
            new UpdateOrderCommand(orderRequestModel.bookingId, orderRequestModel.customerNumber, 
                orderRequestModel.orderNumber, orderRequestModel.wareNumber, orderRequestModel.InOut, id , orderRequestModel.SupplierName , orderRequestModel.ExternalId, orderRequestModel.TotalPallets , orderRequestModel.BottomPallets , orderRequestModel.Comment));

            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await CommandRouter.RouteAsync<DeleteOrderCommand, IdResponse>(new DeleteOrderCommand(id));
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await QueryRouter.QueryAsync<GetOrderById, Order>(new GetOrderById(id));
            return new ObjectResult(result);
        }
    }
}