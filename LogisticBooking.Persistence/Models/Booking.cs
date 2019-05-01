using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Map(x => x.totalPallets).ToColumn("pallets");
            Map(x => x.bookingTime).ToColumn("BookingTime");
            Map(x => x.transporterName).ToColumn("TransporterName");
            Map(x => x.port).ToColumn("Port");
            Map(x => x.actualArrival).ToColumn("ActualArrival");
            Map(x => x.startLoading).ToColumn("StartLoading");
            Map(x => x.endLoading).ToColumn("EndLoading");
            Map(x => x.email).ToColumn("Email");
            Map(x => x.Orders).Ignore();
            Map(x => x.ExternalId).ToColumn("externalid");
            
        }

        
    }

    public class Booking
    {
        
        
    public int ExternalId { get; set; }
        
    public int totalPallets { get; set; }
    public DateTime bookingTime { get; set; }
    public string transporterName { get; set; }
    public int port { get; set; }
    public DateTime actualArrival { get; set; }
    public DateTime startLoading { get; set; }
    public DateTime endLoading { get; set; }

    [ForeignKey("bookingid")] public Guid internalId { get; set; }
    public string email { get; set; }

    public List<Order> Orders { get; set; }

    public Guid TransporterId { get; set; }
    }
}