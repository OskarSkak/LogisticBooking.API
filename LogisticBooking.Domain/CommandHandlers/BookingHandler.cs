using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands.Booking;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using SimpleSoft.Mediator;
using StructureMap.Building;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class BookingHandler : ICommandHandler<CreateBookingCommand, IdResponse>,
        ICommandHandler<DeleteBookingCommand, IdResponse>,
        ICommandHandler<UpdateBookingCommand, IdResponse>

    {
        private readonly IEventRouter _eventRouter;
        private readonly IOrderRepository _orderRepository;
        private readonly ITransporterRepository _transporterRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingHandler(IBookingRepository bookingRepository, IEventRouter eventRouter , IOrderRepository orderRepository , ITransporterRepository transporterRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRouter = eventRouter;
            _orderRepository = orderRepository;
            _transporterRepository = transporterRepository;
        }
        
        public async Task<IdResponse> HandleAsync(CreateBookingCommand cmd, CancellationToken ct)
        {

            
            
            
            if (String.IsNullOrEmpty(cmd.transporterName))
            {
                var transporter = await _transporterRepository.GetByIdAsync(cmd.TransporterId);
                cmd.transporterName = transporter.Name;
            }

          
            
            var result = await _bookingRepository.InsertAsync(new Booking
            {
                
                internalId = cmd.internalId,
                email = cmd.email,
                endLoading = cmd.endLoading,
                startLoading = cmd.startLoading,
                totalPallets = cmd.totalPallets,
                actualArrival = cmd.actualArrival,
                transporterName = cmd.transporterName,
                bookingTime = cmd.bookingTime,
                port = cmd.port,
                TransporterId = cmd.TransporterId,
                ExternalId = cmd.ExternalId
                
            });
  

            List<Order> orders = new List<Order>();
            
            foreach (var order in cmd.Orders)
            {
                
                orders.Add(new Order
                {
                    bookingId = cmd.internalId,
                    customerNumber = 1.ToString(),
                    id = Guid.NewGuid(),
                    InOut = order.InOut,
                    orderNumber = order.orderNumber,
                    wareNumber = order.wareNumber,
                    Comment = order.Comment,
                    ExternalId = order.ExternalId,
                    TotalPallets = order.TotalPallets,
                    BottomPallets = order.TotalPallets,
                    SupplierName = order.SupplierName,
                });
            }

            foreach (var order in orders)
            {
               await _orderRepository.InsertAsync(order);
            }

            return new IdResponse(cmd.Id);
        }

        public async Task<IdResponse> HandleAsync(DeleteBookingCommand cmd, CancellationToken ct)
        {
            var booking = await _bookingRepository.GetByIdAsync(cmd.id);
            var result = await _bookingRepository.DeleteByTAsync(booking);
            return new IdResponse(cmd.id);
        }

        public async Task<IdResponse> HandleAsync(UpdateBookingCommand cmd, CancellationToken ct)
        {
            var result = await _bookingRepository.UpdateAsync(new Booking
            {
                email = cmd.email,
                actualArrival = cmd.actualArrival,
                bookingTime = cmd.bookingTime,
                endLoading = cmd.endLoading,
                port = cmd.port,
                internalId = cmd.internalId,
                startLoading = cmd.startLoading,
                totalPallets = cmd.totalPallets,
                transporterName = cmd.transporterName,
                ExternalId = cmd.ExternalId
            });
            return new IdResponse(cmd.Id);
        }
    }
}