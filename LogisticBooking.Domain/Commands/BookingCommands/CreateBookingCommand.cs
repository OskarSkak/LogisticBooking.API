using System;
using System.Collections.Generic;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.Booking
{
    public class CreateBookingCommand : Command<IdResponse>
    {
        private readonly Guid _transporterId;
        public int totalPallets { get; set; }
        public DateTime bookingTime { get; set; }
        public string transporterName { get; set; }
        public int port { get; set; }
        public DateTime actualArrival { get; set; }
        public DateTime startLoading { get; set; }
        public DateTime endLoading { get; set; }
        public Guid internalId { get; set; }
        public string email { get; set; }
        
        public Guid TransporterId { get; set; }
        
        public int ExternalId { get; set; }
        
        public List<Persistence.Models.Order> Orders { get; set; }


        public CreateBookingCommand( int totalPallets, DateTime bookingTime, string transporterName, int port, DateTime actualArrival, DateTime startLoading, DateTime endLoading, string email , List<Persistence.Models.Order> orders, Guid transporterId, int ExternalId)
        
        {
            TransporterId = transporterId;
            this.totalPallets = totalPallets;
            this.bookingTime = bookingTime;
            this.transporterName = transporterName;
            this.port = port;
            this.actualArrival = actualArrival;
            this.startLoading = startLoading;
            this.endLoading = endLoading;
            this.email = email;
            Orders = orders;
            this.internalId = Guid.NewGuid();
            this.ExternalId = ExternalId;


        }
       
        public CreateBookingCommand(){}

        
        
    }
}