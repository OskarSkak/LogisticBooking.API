using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries.Booking;
using SimpleSoft.Mediator;


namespace LogisticBooking.Queries.QueryHandler
{
    public class BookingQueryHandler : IQueryHandler<BookingsQuery, IList<Booking>>, 
        IQueryHandler<GetBookingById, Booking>
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingQueryHandler(IBookingRepository bookingRepository , IOrderRepository orderRepository)
        {
            _bookingRepository = bookingRepository;
        }
        
        public async Task<IList<Booking>> HandleAsync(BookingsQuery query, CancellationToken ct)
        {
            //Get all
            var result = _bookingRepository.GetAll();
           
            return result;
        }

       /* public async Task<IList<Booking>> HandleAsync(GetBookingsInbetweenDatesQuery query, CancellationToken ct)
        {
            var allBookings = _bookingRepository.GetAll();
            var bookingsBetweenDate = new List<Booking>(); 

            foreach (var booking in allBookings)
            {
                if (!(DateTime.Compare(query.From, booking.BookingTime) < 0) &&
                    !(DateTime.Compare(query.To, booking.BookingTime) > 0))
                {
                    bookingsBetweenDate.Add(booking);
                }
            }

            return bookingsBetweenDate;
        }*/
        

        public async Task<Booking> HandleAsync(GetBookingById query, CancellationToken ct)
        {
            var result = _bookingRepository.GetById(query.id);
            return result;
        }
    }
}