using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{

    public interface IUtilBookingRepository : IBaseRepository<UtilBooking>
    {
        
    }
    
    
    public class UtilBookingRepository : BaseRepository<UtilBooking> , IUtilBookingRepository
    {
        public UtilBookingRepository(IConnectionString connectionString) : base(connectionString)
        {
            
        }
    }
}