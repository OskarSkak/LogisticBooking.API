using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands.Booking;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;

using SimpleSoft.Mediator;
using IUtilBookingRepository = LogisticBooking.Persistence.IUtilBookingRepository;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class BookingHandler : ICommandHandler<CreateBookingCommand, IdResponse>,
        ICommandHandler<DeleteBookingCommand, IdResponse>,
        ICommandHandler<UpdateBookingCommand, IdResponse>

    {



        //************************** PROPERTIES ******************************************
        
        private readonly IEventRouter _eventRouter;
        private readonly IBookingRepository _bookingRepository;

        private readonly IOrderRepository _orderRepository;
        private readonly ITransporterRepository _transporterRepository;
        private readonly IUtilBookingRepository _utilBookingRepository;


        //*************************** CONSTRUCTOR ****************************************
        
        public BookingHandler( IEventRouter eventRouter, IBookingRepository bookingRepository, IOrderRepository orderRepository, ITransporterRepository transporterRepository, IUtilBookingRepository utilBookingRepository)
        {
            
            _eventRouter = eventRouter;
            _bookingRepository = bookingRepository;
            _orderRepository = orderRepository;
            _transporterRepository = transporterRepository;
            _utilBookingRepository = utilBookingRepository;
        }
        
        
        
        //*************************** METHODS ****************************************
        
        public async Task<IdResponse> HandleAsync(CreateBookingCommand cmd, CancellationToken ct)
        {
            if (String.IsNullOrEmpty(cmd.transporterName))
            {
                var transporter = _transporterRepository.GetById(cmd.TransporterId);
                cmd.transporterName = transporter.Name;
                cmd.email = transporter.Email;
            }


            _bookingRepository.Insert(new Booking
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
                _orderRepository.Insert(order);
            }

            

            
            var updateRequest = _utilBookingRepository.Update();

            return new IdResponse(cmd.Id);
        }

        public async Task<IdResponse> HandleAsync(DeleteBookingCommand cmd, CancellationToken ct)
        {
            var booking =  _bookingRepository.GetById(cmd.id);
            var result =  _bookingRepository.DeleteByT(booking);
            return new IdResponse(cmd.id);
        }

        public async Task<IdResponse> HandleAsync(UpdateBookingCommand cmd, CancellationToken ct)
        {
            var result = _bookingRepository.Update(new Booking
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