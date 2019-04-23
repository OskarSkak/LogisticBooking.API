using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dommel;
using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Task<object> GetAllCustom();
    }
    
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        private readonly IConnectionString _connectionString;

        public BookingRepository(IConnectionString connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<object> GetAllCustom()
        {

            using (var conn = new Npgsql.NpgsqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var dictionary = new Dictionary<Guid, Booking>();

                string sql = "SELECT * from bookings as A INNER JOIN orders o on A.internalid = o.bookingid";
                
                var list = conn.Query<Booking, Order, Booking>(sql, (booking, order ) =>
                {
                   
                    
                    Booking bookingEntry;

                    if (!dictionary.TryGetValue(booking.internalId, out bookingEntry))
                    {
                        bookingEntry = booking;
                        bookingEntry.Orders = new List<Order>();
                        
                        dictionary.Add(bookingEntry.internalId , bookingEntry);
                        
                    }
                    
                    bookingEntry.Orders.Add(order);
                    
                    return bookingEntry;
                    
                   
                }).Distinct()
                    .ToList();

                

                Console.WriteLine(list);
                return list;
            } 
            
          
        }    
    }
}