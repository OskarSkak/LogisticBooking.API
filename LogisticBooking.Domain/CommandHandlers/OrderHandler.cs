using System;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Domain.Commands.Order;
using LogisticBooking.Events.Events;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class OrderHandler : ICommandHandler<CreateOrderCommand , IdResponse>,
    ICommandHandler<DeleteOrderCommand, IdResponse>,
    ICommandHandler<UpdateOrderCommand, IdResponse>
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
            var result = await _orderRepository.InsertAsync(new Order
            {
                id = cmd.id,
                bookingId = cmd.bookingId,
                customerNumber = cmd.customerNumber,
                InOut = cmd.InOut,
                orderNumber = cmd.orderNumber,
                wareNumber = cmd.wareNumber
            });
            return new IdResponse(cmd.id);
        }

        public async Task<IdResponse> HandleAsync(DeleteOrderCommand cmd, CancellationToken ct)
        {
            var order = await _orderRepository.GetByIdAsync(cmd.id);
            var result = await _orderRepository.DeleteByTAsync(order);
            return new IdResponse(cmd.id);
        }

        public async Task<IdResponse> HandleAsync(UpdateOrderCommand cmd, CancellationToken ct)
        {
            var result = await _orderRepository.UpdateAsync(new Order
            {
                id = cmd.id,
                bookingId = cmd.bookingId,
                customerNumber = cmd.customerNumber,
                InOut = cmd.InOut,
                orderNumber = cmd.orderNumber,
                wareNumber = cmd.wareNumber,
                SupplierName = cmd.SupplierName,
                ExternalId = cmd.ExternalId,
                Comment = cmd.Comment,
                TotalPallets = cmd.TotalPallets,
                BottomPallets = cmd.BottomPallets
                
            });
            return new IdResponse(cmd.id);
        }
    }
}