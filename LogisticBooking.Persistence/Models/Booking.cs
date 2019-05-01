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
            Map(x => x.InternalId).ToColumn("Internalid").IsKey();
            Map(x => x.TotalPallets).ToColumn("pallets");
            Map(x => x.BookingTime).ToColumn("BookingTime");
            Map(x => x.TransporterName).ToColumn("TransporterName");
            Map(x => x.Port).ToColumn("Port");
            Map(x => x.ActualArrival).ToColumn("ActualArrival");
            Map(x => x.StartLoading).ToColumn("StartLoading");
            Map(x => x.EndLoading).ToColumn("EndLoading");
            Map(x => x.Email).ToColumn("Email");
            Map(x => x.Orders).Ignore();
            Map(x => x.ExternalId).ToColumn("externalid");
            
        }

        
    }

    public class Booking
    {
        
        
    public int ExternalId { get; set; }
        
    public int TotalPallets { get; set; }
    public DateTime BookingTime { get; set; }
    
    public string TransporterName { get; set; }
    public int Port { get; set; }
    public DateTime ActualArrival { get; set; }
    public DateTime StartLoading { get; set; }
    public DateTime EndLoading { get; set; }

    [ForeignKey("bookingid")] 
    public Guid InternalId { get; set; }
    public string Email { get; set; }

    public List<Order> Orders { get; set; }

    public Guid TransporterId { get; set; }
    }
}