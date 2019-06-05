using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{

    public interface IOrderRepository : IBaseSqlRepository<Order>
    {
        
    }
    
    public class OrderRepository : BaseBackendSql<Order> , IOrderRepository
    {
        
        public OrderRepository(ISqlBackendConnectionString connectionString) : base(connectionString)
        {
            
        }

         
        
    }
}