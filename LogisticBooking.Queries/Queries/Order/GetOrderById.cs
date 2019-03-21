using System;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.Queries
{
    public class GetOrderById : Query<Order>
    {
        public Guid id { get; set; }

        public GetOrderById(Guid id)
        {
            this.id = id;
        }
        
    }
}