using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class OrderHandler : ICommandHandler<CreateOrderCommand , IdResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public async Task<IdResponse> HandleAsync(CreateOrderCommand cmd, CancellationToken ct)
        {

            var id = Guid.NewGuid();
            var result = await _orderRepository.InsertAsync(new Order
            {
                OrderName = cmd.OrderName,
                id = id
            });
            
            
            
            return new IdResponse(id);
        }
    }
}