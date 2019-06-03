using LogisticBooking.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DbContext = System.Data.Entity.DbContext;

namespace LogisticBooking.Persistence.BaseRepository
{
    public class UtilityContext : DbContext
    {
        
        
        public System.Data.Entity.DbSet<UtilBooking> UtilBookings { get; set; }
    }
}