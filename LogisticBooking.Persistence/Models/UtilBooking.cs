using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{

    public class UtilBookingMap : DommelEntityMap<UtilBooking>
    {
        public UtilBookingMap()
        {
            ToTable("utilbooking");
            Map(x => x.bookingid).ToColumn("bookingid").IsKey();
        }
    }
    
    
    
    public class UtilBooking
    {
        public int bookingid { get; set; }
    }
}