using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.Booking
{
    public class UpdateBookingCommand : Command<IdResponse>
    {
        public UpdateBookingCommand(int totalPallets, DateTime bookingTime, string transporterName, int port, DateTime actualArrival, DateTime startLoading, DateTime endLoading, string email, Guid internalId  , int ExternalId )
        {
            this.totalPallets = totalPallets;
            this.bookingTime = bookingTime;
            this.transporterName = transporterName;
            this.port = port;
            this.actualArrival = actualArrival;
            this.startLoading = startLoading;
            this.endLoading = endLoading;
            this.email = email;
            this.internalId = internalId;
            this.ExternalId = ExternalId;

        }
        
        

        public int ExternalId { get; set; }
        public int totalPallets { get; set; }
        public DateTime bookingTime { get; set; }
        public string transporterName { get; set; }
        public int port { get; set; }
        public DateTime actualArrival { get; set; }
        public DateTime startLoading { get; set; }
        public DateTime endLoading { get; set; }
        public string email { get; set; }
        public Guid internalId { get; set; }
        

    }
}