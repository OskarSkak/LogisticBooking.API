using Microsoft.EntityFrameworkCore;

namespace LogisticBooking.Persistence.Models
{
    public class BackendDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        
        public DbSet<UtilBooking> UtilBookings { get; set; }
        
        public DbSet<Interval> Intervals { get; set; }
        
        public DbSet<Schedule> Schedules { get; set; }


        public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
        {
            
        }
        
        

        
    }
}