using System;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.API.RequestModels
{
    public class CreateBookingRequestModel
    {
        
            public Schedule Schedule { get; set; }
            public Booking Booking { get; set; }
            
            public Guid IntervalId { get; set; }
        
    
    }
}