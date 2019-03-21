using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        
    }
    
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(IConnectionString connectionString) : base(connectionString)
        {
            
        }
    }
}