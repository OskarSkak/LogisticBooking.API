using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Persistence;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.QueryHandler
{
    public class OrderQueryHandler : IQueryHandler<OrdersQuery , IList<Order>>, IQueryHandler<GetOrderById, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<IList<Order>> HandleAsync(OrdersQuery query, CancellationToken ct)
        {
            var result =  _orderRepository.GetAll();

            return result.ToList();
        }

        public async Task<Order> HandleAsync(GetOrderById query, CancellationToken ct)
        {
            var result = await _orderRepository.GetById(query.id);
            return result;
        }
    }
}