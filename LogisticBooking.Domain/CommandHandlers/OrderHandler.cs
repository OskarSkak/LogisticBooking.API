using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands.Order;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
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
            var result = _orderRepository.Insert(new Order
            {
                Id = cmd.id,
                BookingId = cmd.bookingId,
                CustomerNumber = cmd.customerNumber,
                InOut = cmd.InOut,
                OrderNumber = cmd.orderNumber,
                WareNumber = cmd.wareNumber
            });
            return new IdResponse(cmd.id);
        }

        public async Task<IdResponse> HandleAsync(DeleteOrderCommand cmd, CancellationToken ct)
        {
            var order = await _orderRepository.GetById(cmd.id);
            var result = _orderRepository.DeleteByT(order);
            return new IdResponse(cmd.id);
        }

        public async Task<IdResponse> HandleAsync(UpdateOrderCommand cmd, CancellationToken ct)
        {
            var result = _orderRepository.Update(new Order
            {
                Id = cmd.id,
                BookingId = cmd.bookingId,
                CustomerNumber = cmd.customerNumber,
                InOut = cmd.InOut,
                OrderNumber = cmd.orderNumber,
                WareNumber = cmd.wareNumber,
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