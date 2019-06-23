using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LogisticBooking.API
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<RegistrationKey> RegistrationKey { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:logistictechnologies.database.windows.net,1433;Initial Catalog=test;Persist Security Info=False;User ID=LG_admin;Password=Hjallesevej50;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasIndex(e => e.SubjectId);

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ClaimValue)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.SubjectId);
            });

            modelBuilder.Entity<RegistrationKey>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasColumnName("email");
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasIndex(e => e.SubjectId);

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.SubjectId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
