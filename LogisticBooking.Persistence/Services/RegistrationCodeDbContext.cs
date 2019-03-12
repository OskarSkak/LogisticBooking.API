using LogisticBooking.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticBooking.Persistence.Services
{
    public class RegistrationCodeDbContext : DbContext
    {
        public RegistrationCodeDbContext(DbContextOptions<RegistrationCodeDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<RegistrationKey> Keys { get; set; }
    }
}