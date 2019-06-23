using System;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{
    public class SupplierMap : DommelEntityMap<Supplier>
    {
        public SupplierMap()
        {
            ToTable("Suppliers");
            Map(x => x.ID).ToColumn("ID").IsKey();
            Map(x => x.Email).ToColumn("Email");
            Map(x => x.Telephone).ToColumn("Telephone");
            Map(x => x.Name).ToColumn("Name");
        }
        
    }

    
    public class Supplier
    {
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Name { get; set; }
        public Guid ID { get; set; }
        
        public DateTime arriveTime { get; set; }
    }
}
