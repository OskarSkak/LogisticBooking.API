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
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.BookingId).ToColumn("BookingId");
            Map(x => x.CustomerNumber).ToColumn("CustomerNumber");
            Map(x => x.OrderNumber).ToColumn("OrderNumber");
            Map(x => x.WareNumber).ToColumn("WareNumber");
            Map(x => x.InOut).ToColumn("InOut");
            Map(x => x.SupplierName).ToColumn("suppliername");
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        
        public string Comment { get; set; }
        
        public int TotalPallets { get; set; }
        public int BottomPallets { get; set; }
        public string ExternalId { get; set; }
        
        public Guid BookingId { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderNumber { get; set; }
        public int WareNumber { get; set; }
        public string InOut { get; set; }
        
        public string SupplierName { get; set; }
    }
}


