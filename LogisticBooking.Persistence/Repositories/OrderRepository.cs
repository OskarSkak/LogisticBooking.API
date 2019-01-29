using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{

    public interface IOrderRepository : IBaseRepository<Order>
    {
        
    }
    
    public class OrderRepository : BaseRepository<Order> , IOrderRepository
    {
        public OrderRepository(IConnectionString connectionString) : base(connectionString)
        {
            
        }
    }
}