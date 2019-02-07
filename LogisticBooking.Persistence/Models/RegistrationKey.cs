using System;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{

    public class RegistationsKeyMap : DommelEntityMap<RegistrationKey>
    {
        public RegistationsKeyMap()
        {
            ToTable("RegistrationKey");
            Map(x => x.id).IsKey().ToColumn("id");
            Map(x => x.email).ToColumn("email");
        }
    }
    
    public class RegistrationKey
    {
        public string id { get; set; }
        public string email { get; set; }
    }
}