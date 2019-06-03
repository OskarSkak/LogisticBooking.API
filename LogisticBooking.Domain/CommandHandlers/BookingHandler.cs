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

namespace LogisticBooking.Domain.CommandHandlers
{
    public class BookingHandler : ICommandHandler<CreateBookingCommand, IdResponse>,
        ICommandHandler<DeleteBookingCommand, IdResponse>,
        ICommandHandler<UpdateBookingCommand, IdResponse>

    {
        

        //************************** PROPERTIES ******************************************
        
        private readonly IEventRouter _eventRouter;
        private readonly IOrderRepository _orderRepository;
        private readonly ITransporterRepository _transporterRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUtilBookingRepository _utilBookingRepository;
        
        
        //*************************** CONSTRUCTOR ****************************************
        
        public BookingHandler(IBookingRepository bookingRepository, IEventRouter eventRouter , IOrderRepository orderRepository , ITransporterRepository transporterRepository , IUtilBookingRepository utilBookingRepository)
        {
            _utilBookingRepository = utilBookingRepository;
            _bookingRepository = bookingRepository;
            _eventRouter = eventRouter;
            _orderRepository = orderRepository;
            _transporterRepository = transporterRepository;
        }
        
        
        
        //*************************** METHODS ****************************************
        
        public async Task<IdResponse> HandleAsync(CreateBookingCommand cmd, CancellationToken ct)
        {
            if (String.IsNullOrEmpty(cmd.transporterName))
            {
                var transporter = await _transporterRepository.GetByIdAsync(cmd.TransporterId);
                cmd.transporterName = transporter.Name;
                cmd.email = transporter.Email;
            }

          
            
            var result = await _bookingRepository.InsertAsync(new Booking
            {
                
                InternalId = cmd.internalId,
                Email = cmd.email,
                EndLoading = DateTime.Now,
                StartLoading = DateTime.Now,
                TotalPallets = cmd.totalPallets,
                ActualArrival = DateTime.Now,
                TransporterName = cmd.transporterName,
                BookingTime = cmd.bookingTime,
                Port = cmd.port,
                TransporterId = cmd.TransporterId,
                ExternalId = cmd.ExternalId
               
                
            });
  

            List<Order> orders = new List<Order>();
            
            foreach (var order in cmd.Orders)
            {
                
                orders.Add(new Order
                {
                    BookingId = cmd.internalId,
                    CustomerNumber = 1.ToString(),
                    Id = Guid.NewGuid(),
                    InOut = order.InOut,
                    OrderNumber = order.OrderNumber,
                    WareNumber = order.WareNumber,
                    Comment = order.Comment,
                    ExternalId = order.ExternalId,
                    TotalPallets = order.TotalPallets,
                    BottomPallets = order.TotalPallets,
                    SupplierName = order.SupplierName
                    
                });
            }

            foreach (var order in orders)
            {
               await _orderRepository.InsertAsync(order);
            }

            var utilList = await _utilBookingRepository.GetAllAsync();

            var bookingid = utilList.FirstOrDefault();
            
            var updateRequest = await _utilBookingRepository.UpdateUtil(bookingid);

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
                Email = cmd.email,
                ActualArrival = cmd.actualArrival,
                BookingTime = cmd.bookingTime,
                EndLoading = cmd.endLoading,
                Port = cmd.port,
                InternalId = cmd.internalId,
                StartLoading = cmd.startLoading,
                TotalPallets = cmd.totalPallets,
                TransporterName = cmd.transporterName,
                ExternalId = cmd.ExternalId
            });
            return new IdResponse(cmd.Id);
        }
    }
}