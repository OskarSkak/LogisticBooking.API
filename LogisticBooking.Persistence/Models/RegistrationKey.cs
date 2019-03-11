using System;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{

    public class RegistationsKeyMap : DommelEntityMap<RegistrationKey>
    {
        public RegistationsKeyMap()
        {
            ToTable("Users");
            Map(x => x.SubjectId).IsKey().ToColumn("SubjectId");
            Map(x => x.Username).ToColumn("Username");
            Map(x => x.IsActive).ToColumn("IsActive");
        }
    }
    
    public class RegistrationKey
    {
        public string SubjectId { get; set; }
        public string Username { get; set; }
        
        public bool IsActive { get; set; }
    }
}