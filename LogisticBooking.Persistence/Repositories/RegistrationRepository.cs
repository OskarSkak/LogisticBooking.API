using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{

    public interface IRegistrationRepository : IBaseSqlRepository<RegistrationKey> 
    {
        
    }


    public class RegistrationRepository : BaseBackendSql<RegistrationKey>, IRegistrationRepository
    {
        public RegistrationRepository(ISqlBackendConnectionString connectionString) : base(connectionString)
        {
            
        }

        
    }
    
        
    
}