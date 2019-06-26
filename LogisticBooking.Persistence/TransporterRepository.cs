using System;
using System.Collections.Generic;
using System.Linq;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence
{

    public interface ITransporterRepository
    {
        Transporter GetById(Guid id);
        bool DeleteById(Guid id);
        bool DeleteByT(Transporter t);
        bool Update(Transporter t);
        List<Transporter> GetAll();
        bool Insert(Transporter t);
        bool InsertMany(List<Transporter> t);
    }
    
    public class TransporterRepository : ITransporterRepository
    {
        private readonly BackendDbContext _context;

        public TransporterRepository(BackendDbContext context)
        {
            _context = context;
        }
        
        
        public Transporter GetById(Guid id)
        {
            return _context.Transporters.FirstOrDefault(order => order.ID == id);
            
        }

        public bool DeleteById(Guid id)
        {
            _context.Transporters.Remove(_context.Transporters.FirstOrDefault(order => order.ID == id));
            var result = Save();
            return result;
        }

        public bool DeleteByT(Transporter t)
        {
            _context.Transporters.Remove(t);
            var result = Save();
            return result;
        }

        public bool Update(Transporter t)
        {
            _context.Transporters.Update(t);
            var result = Save();
            return result;
        }

        public List<Transporter> GetAll()
        {
            return _context.Transporters.ToList();
        }

        public bool Insert(Transporter t)
        {
            _context.Transporters.Add(t);
            var result = Save();
            return result;
        }

        public bool InsertMany(List<Transporter> t)
        {
            
            _context.Transporters.AddRange(t);
            var result = Save();
            return result;
        }
        
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}