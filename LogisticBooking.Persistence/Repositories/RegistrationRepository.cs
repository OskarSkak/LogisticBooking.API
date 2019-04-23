using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{

    public interface IRegistrationRepository : IBaseSqlRepository<RegistrationKey> 
    {
        
    }


    public class RegistrationRepository : BaseSqlRepository<RegistrationKey>, IRegistrationRepository
    {
        public RegistrationRepository(ISqlConnectionString connectionString) : base(connectionString)
        {
            
        }

        
    }
    
        
    
}