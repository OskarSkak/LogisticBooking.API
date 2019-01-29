using System;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{

    public class OrderMap : DommelEntityMap<Order>
    {
        public OrderMap()
        {
            ToTable("orders");
            Map(x => x.id).ToColumn("id").IsKey();
            Map(x => x.OrderName).ToColumn("ordername");
        }
    }
    
    public class Order
    {
        public Guid id { get; set; }
        public string OrderName { get; set; }
        
    }
}