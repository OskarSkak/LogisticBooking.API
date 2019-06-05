using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dommel;
using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{
    public interface IBookingRepository : IBaseSqlRepository<Booking>
    {
        Task<object> GetAllCustom();
    }
    
    public class BookingRepository : BaseBackendSql<Booking>, IBookingRepository
    {
        private readonly ISqlBackendConnectionString _connectionString;

        public BookingRepository(ISqlBackendConnectionString connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<object> GetByIdCustom(Guid guid)
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var dictionary = new Dictionary<Guid, Booking>();

                string sql = "SELECT * from bookings WHERE id = '" + guid + "'";
                var booking = conn.Query(sql);
                return booking;
            }
        }

        public async Task<object> GetAllCustom()
        {

            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var dictionary = new Dictionary<Guid, Booking>();

                string sql = "SELECT * from bookings as A INNER JOIN orders o on A.internalid = o.bookingid";
                
                var list = conn.Query<Booking, Order, Booking>(sql, (booking, order ) =>
                {
                    Booking bookingEntry;

                    if (!dictionary.TryGetValue(booking.InternalId, out bookingEntry))
                    {
                        bookingEntry = booking;
                        bookingEntry.Orders = new List<Order>();
                        
                        dictionary.Add(bookingEntry.InternalId , bookingEntry);
                        
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