using LogisticBooking.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace LogisticBooking.Persistence.BaseRepository
{
    public class UtilityContext : DbContext
    {
        
        
        public DbSet<UtilBooking> UtilBookings { get; set; }
    }
}