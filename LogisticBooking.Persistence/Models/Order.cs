using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{

    public class OrderMap : DommelEntityMap<Order>
    {
        public OrderMap()
        {
            ToTable("orders");
            Map(x => x.id).ToColumn("Id").IsKey();
            Map(x => x.bookingId).ToColumn("BookingId");
            Map(x => x.customerNumber).ToColumn("CustomerNumber");
            Map(x => x.orderNumber).ToColumn("OrderNumber");
            Map(x => x.wareNumber).ToColumn("WareNumber");
            Map(x => x.InOut).ToColumn("InOut");
        }
    }

    public class Order
    {
        public Guid id { get; set; }
        
        public string Comment { get; set; }
        
        public int TotalPallets { get; set; }
        public int BottomPallets { get; set; }
        public string ExternalId { get; set; }
        
        public Guid bookingId { get; set; }
        public string customerNumber { get; set; }
        public string orderNumber { get; set; }
        public int wareNumber { get; set; }
        public string InOut { get; set; }
    }
}


