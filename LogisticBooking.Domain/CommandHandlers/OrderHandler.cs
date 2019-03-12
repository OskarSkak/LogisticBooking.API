using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Events.Events;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{/*
    public class OrderHandler : ICommandHandler<CreateOrderCommand , IdResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventRouter _eventRouter;


        public OrderHandler(IOrderRepository orderRepository , IEventRouter eventRouter )
        {
            _orderRepository = orderRepository;
            _eventRouter = eventRouter;
        }
        
        public async Task<IdResponse> HandleAsync(CreateOrderCommand cmd, CancellationToken ct)
        {

            var id = Guid.NewGuid();
            var result = await _orderRepository.InsertAsync(new Order
            {
                OrderName = cmd.OrderName,
                id = id
            });

                // Do this to raise an event
            _eventRouter.EventAsync(new OrderCreatedEvent());
            
            
            return new IdResponse(id);
        }
    }*/
}