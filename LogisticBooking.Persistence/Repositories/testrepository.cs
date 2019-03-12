using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;


namespace LogisticBooking.Persistence.Repositories
{

    public interface ItestRepository : IBaseRepository<RegistrationKey>
    {
        
    }


    public class testrepository : BaseRepository<RegistrationKey>, ItestRepository
    
        
    
    {
        public testrepository(IConnectionString connectionString) : base(connectionString)
        {
            
        }
    }
}