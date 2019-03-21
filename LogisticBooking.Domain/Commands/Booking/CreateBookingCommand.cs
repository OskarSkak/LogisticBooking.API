using System;
using LogisticBooking.Documents.Documents;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.Commands.Booking
{
    public class CreateBookingCommand : Command<IdResponse>
    {
        public int totalPallets { get; set; }
        public DateTime bookingTime { get; set; }
        public string transporterName { get; set; }
        public int port { get; set; }
        public DateTime actualArrival { get; set; }
        public DateTime startLoading { get; set; }
        public DateTime endLoading { get; set; }
        public Guid internalId { get; set; }
        public string email { get; set; }
        
        public CreateBookingCommand(int totalPallets, DateTime bookingTime, string transporterName, int port, DateTime actualArrival, DateTime startLoading, DateTime endLoading, string email)
        {
            this.totalPallets = totalPallets;
            this.bookingTime = bookingTime;
            this.transporterName = transporterName;
            this.port = port;
            this.actualArrival = actualArrival;
            this.startLoading = startLoading;
            this.endLoading = endLoading;
            this.email = email;
            this.internalId = Guid.NewGuid();
        }
       
        public CreateBookingCommand(){}

        
        
    }
}