using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{
    public interface ISupplierRepository : IBaseSqlRepository<Supplier>
    {

    }

    public class SupplierRepository : BaseBackendSql<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ISqlBackendConnectionString connectionString): base(connectionString)
        {

        }
    }
    
}
