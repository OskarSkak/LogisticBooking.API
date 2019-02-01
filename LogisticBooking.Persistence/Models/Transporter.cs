using System;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{
    public class TransporterMap : DommelEntityMap<Transporter>
    {
        public TransporterMap()
        {
            ToTable("Transporters");
            Map(x => x.ID).ToColumn("ID").IsKey();
            Map(x => x.Email).ToColumn("Email");
            Map(x => x.Telephone).ToColumn("Telephone");
            Map(x => x.Address).ToColumn("Address");
            Map(x => x.Name).ToColumn("Name");
        }
    }

    public class Transporter
    {
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public Guid ID { get; set; }
    }
}
