using System;

namespace LogisticBooking.API.RequestModels
{
    public class OrderRequestModel
    {
        
        public string Comment { get; set; }
        
        public int TotalPallets { get; set; }
        public int BottomPallets { get; set; }
        public string ExternalId { get; set; }
        public Guid bookingId { get; set; }
        public string customerNumber { get; set; }
        public string orderNumber { get; set; }
        public int wareNumber { get; set; }
        public string InOut { get; set; }
    }
}