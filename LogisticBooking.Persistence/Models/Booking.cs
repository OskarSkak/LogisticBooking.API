using System;
using Microsoft.EntityFrameworkCore.Design;
using StructureMap.Building;
using Dapper.FluentMap.Dommel.Mapping;

namespace LogisticBooking.Persistence.Models
{
    public class BookingMap : DommelEntityMap<Booking>
    {
        public BookingMap()
        {
            ToTable("Bookings");
            Map(x => x.internalId).ToColumn("Internalid").IsKey();
            Map(x => x.totalPallets).ToColumn("Pallets");
            Map(x => x.bookingTime).ToColumn("BookingTime");
            Map(x => x.transporterName).ToColumn("TransporterName");
            Map(x => x.port).ToColumn("Port");
            Map(x => x.actualArrival).ToColumn("ActualArrival");
            Map(x => x.startLoading).ToColumn("StartLoading");
            Map(x => x.endLoading).ToColumn("EndLoading");
            Map(x => x.email).ToColumn("Email");
        }
    }
    
    public class Booking
    {
        public int totalPallets { get; set; }
        public DateTime bookingTime { get; set; }
        public string transporterName { get; set; }
        public int port { get; set; }
        public DateTime actualArrival { get; set; }
        public DateTime startLoading { get; set; }
        public DateTime endLoading { get; set; }
        public Guid internalId { get; set; }
        public string email { get; set; }
    }
}