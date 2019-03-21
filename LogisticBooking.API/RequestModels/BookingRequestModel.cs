using System;

namespace LogisticBooking.API.RequestModels
{
    public class BookingRequestModel
    {
        public int totalPallets { get; set; }
        public DateTime bookingTime { get; set; }
        public string transporterName { get; set; }
        public int port { get; set; }
        public DateTime actualArrival { get; set; }
        public DateTime startLoading { get; set; }
        public DateTime endLoading { get; set; }
        public string email { get; set; }
    }
}