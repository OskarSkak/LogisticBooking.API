using System.Collections.Generic;
using AutoMapper;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.API.RequestModels.Resources
{
    public static class RequestModelMapper
    {
        public static List<BookingRequestModel> MapBooking(List<Booking> source, List<BookingRequestModel> destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Booking, BookingRequestModel>();
                cfg.CreateMap<Order, OrderRequestModel>();
            });

            IMapper mapper = config.CreateMapper();
            
            mapper.Map<List<Booking>, List<BookingRequestModel>>(source, destination);
            
            

            return destination;
        }
    }
}