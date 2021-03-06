// <auto-generated />
using System;
using LogisticBooking.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogisticBooking.API.Migrations
{
    [DbContext(typeof(BackendDbContext))]
    partial class BackendDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Booking", b =>
                {
                    b.Property<Guid>("InternalId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActualArrival");

                    b.Property<DateTime>("BookingTime");

                    b.Property<string>("Email");

                    b.Property<DateTime>("EndLoading");

                    b.Property<int>("ExternalId");

                    b.Property<int>("Port");

                    b.Property<DateTime>("StartLoading");

                    b.Property<int>("TotalPallets");

                    b.Property<Guid>("TransporterId");

                    b.Property<string>("TransporterName");

                    b.HasKey("InternalId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Interval", b =>
                {
                    b.Property<Guid>("IntervalId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookingId");

                    b.Property<int>("BottomPallets");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsBooked");

                    b.Property<int>("RemainingPallets");

                    b.Property<Guid?>("ScheduleId");

                    b.Property<Guid>("SecondaryBookingId");

                    b.Property<DateTime>("StartTime");

                    b.Property<Guid>("TransporterId");

                    b.HasKey("IntervalId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Intervals");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookingId");

                    b.Property<int>("BottomPallets");

                    b.Property<string>("Comment");

                    b.Property<string>("CustomerNumber");

                    b.Property<string>("ExternalId");

                    b.Property<string>("InOut");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("SupplierName");

                    b.Property<int>("TotalPallets");

                    b.Property<int>("WareNumber");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Schedule", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<int>("MischellaneousPallets");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ScheduleDay");

                    b.Property<int>("shifts");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Supplier", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("Telephone");

                    b.Property<DateTime>("arriveTime");

                    b.HasKey("ID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Transporter", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("Telephone");

                    b.HasKey("ID");

                    b.ToTable("Transporters");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.UtilBooking", b =>
                {
                    b.Property<int>("bookingid");

                    b.HasKey("bookingid");

                    b.ToTable("UtilBookings");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Interval", b =>
                {
                    b.HasOne("LogisticBooking.Persistence.Models.Schedule")
                        .WithMany("Intervals")
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("LogisticBooking.Persistence.Models.Order", b =>
                {
                    b.HasOne("LogisticBooking.Persistence.Models.Booking")
                        .WithMany("Orders")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
