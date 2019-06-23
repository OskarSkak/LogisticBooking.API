using System.Linq;
using LogisticBooking.Persistence.Models;
using NpgsqlTypes;

namespace LogisticBooking.Persistence
{
    public interface IUtilBookingRepository
    {
        bool Update();
        UtilBooking GetUtilBooking();

        void Insert(UtilBooking booking);
    }
    
    public class UtilBookingRepository : IUtilBookingRepository
    {
        private readonly BackendDbContext _context;

        public UtilBookingRepository(BackendDbContext context)
        {
            _context = context;
        }

        public bool Update()
        {
           var result =  _context.UtilBookings.FirstOrDefault();
           _context.UtilBookings.Remove(result);
           UtilBooking util = new UtilBooking();
           util.bookingid = result.bookingid + 1;
           _context.UtilBookings.Add(util);

           return Save();
        }

        public UtilBooking GetUtilBooking()
        {
            return _context.UtilBookings.FirstOrDefault();
        }

        public void Insert(UtilBooking booking)
        {
            _context.UtilBookings.Add(booking);
            Save();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}