using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using LogisticBooking.Persistence.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LogisticBooking.Persistence
{

    public interface IBookingRepository 
    {
        Booking GetById(Guid id);
        bool DeleteById(Guid id);
        bool DeleteByT(Booking t);
        bool Update(Booking t);
        List<Booking> GetAll();
        bool Insert(Booking t);
        bool InsertMany(List<Booking> t);
    }
    
    
    public class BookingRepository : IBookingRepository
    {
        private readonly BackendDbContext _context;

        public BookingRepository(BackendDbContext context)
        {
            _context = context;
        }


        public Booking GetById(Guid id)
        {
            var result =  _context.Bookings.AsNoTracking().FirstOrDefault(x => x.InternalId == id);
            Save();
            return result;

        }

        public bool DeleteById(Guid id)
        {
           var bookingToBeDeleted = _context.Bookings.FirstOrDefault(booking => booking.InternalId == id);
           _context.Bookings.Remove(bookingToBeDeleted);
           var result = Save();
           return result;
        }

        public bool DeleteByT(Booking t)
        {
            _context.Bookings.Remove(t);
            var result = Save();
            return result;
        }

        public bool Update(Booking t)
        {
            _context.Bookings.Update(t);
            return Save();
        }

        public List<Booking> GetAll()
        {
           var result =  _context.Bookings.Include(s => s.Orders).ToList();
           Save();
           return result;
        }

        public bool Insert(Booking t)
        {
            _context.Bookings.Add(t);
            var result = Save();
            return result;
        }

        public bool InsertMany(List<Booking> t)
        {
            _context.Bookings.AddRange(t);
            var result = Save();
            return result;
        }
        
        private bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}