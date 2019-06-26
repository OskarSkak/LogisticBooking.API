using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bookingid { get; set; }
    }
}