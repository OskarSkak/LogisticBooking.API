using System;

namespace LogisticBooking.API.RequestModels
{
    public class OrderRequestModel
    {
        public Guid bookingId { get; set; }
        public string customerNumber { get; set; }
        public string orderNumber { get; set; }
        public int wareNumber { get; set; }
        public string InOut { get; set; }
    }
}