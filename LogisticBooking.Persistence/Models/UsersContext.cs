using Microsoft.EntityFrameworkCore;

namespace LogisticBooking.Persistence.Models
{
    public class UsersContext : DbContext
    {
        private DbSet<RegistrationKey> Users { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            
    
           optionsBuilder.UseSqlServer("Server=tcp:logistictechnologies.database.windows.net,1433;Initial Catalog=test;Persist Security Info=False;User ID=LG_admin;Password=Hjallesevej50;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
            
    }
    
    
}