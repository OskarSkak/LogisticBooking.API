using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using LogisticBooking.Queries.Queries;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.QueryHandler
{
    public class OrderQueryHandler : IQueryHandler<OrdersQuery , IList<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<IList<Order>> HandleAsync(OrdersQuery query, CancellationToken ct)
        {
            var result = await _orderRepository.GetAllAsync();

            return result.ToList();
        }
    }
}