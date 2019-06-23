using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticBooking.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticBooking.Persistence
{

    public interface IOrderRepository
    {
        Task<Order> GetById(Guid id);
        bool DeleteById(Guid id);
        bool DeleteByT(Order t);
        bool Update(Order t);
        List<Order> GetAll();
        bool Insert(Order t);
        bool InsertMany(List<Order> t);
    }
    
    public class OrderRepository : IOrderRepository
    {
        private readonly BackendDbContext _context;

        public OrderRepository(BackendDbContext context)
        {
            _context = context;
        }
        
        public async Task<Order> GetById(Guid id)
        {
            var result = await  _context.Orders.AsNoTracking().ToListAsync();
            
            return result.FirstOrDefault(x => x.Id == id);

        }

        public bool DeleteById(Guid id)
        {
            _context.Orders.Remove(_context.Orders.FirstOrDefault(order => order.BookingId == id));
            var result = Save();
            return result;
        }

        public bool DeleteByT(Order t)
        {
            _context.Orders.Remove(t);
            var result = Save();
            return result;
        }

        public bool Update(Order t)
        {
            _context.Orders.Update(t);
            
            var result = Save();
            return result;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public bool Insert(Order t)
        {
            _context.Orders.Add(t);
            var result = Save();
            return result;
        }

        public bool InsertMany(List<Order> t)
        {
            
            _context.Orders.AddRange(t);
            var result = Save();
            return result;
        }
        
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        
     
       
    }
    
}