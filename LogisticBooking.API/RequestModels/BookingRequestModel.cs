using System;
using System.Collections.Generic;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.API.RequestModels
{
    public class BookingRequestModel
    {
        
        
        public int ExternalId { get; set; }
        public int totalPallets { get; set; }
        public DateTime bookingTime { get; set; }
        public string transporterName { get; set; }
        public int port { get; set; }
        public DateTime actualArrival { get; set; }
        public DateTime startLoading { get; set; }
        public DateTime endLoading { get; set; }
        public string email { get; set; }
        
        public List<OrderRequestModel> OrderViewModels { get; set; }
    }
}