using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public string Comment { get; set; }
        
        public int TotalPallets { get; set; }
        public int BottomPallets { get; set; }
        public string ExternalId { get; set; }
        
        public virtual Guid BookingId { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderNumber { get; set; }
        public int WareNumber { get; set; }
        public string InOut { get; set; }
        
        public string SupplierName { get; set; }
        
        
    }
}


