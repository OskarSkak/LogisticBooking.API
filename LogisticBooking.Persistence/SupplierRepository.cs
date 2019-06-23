using System;
using System.Collections.Generic;

using System.Linq;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence
{

    public interface ISupplierRepository
    {
        Supplier GetById(Guid id);
        bool DeleteById(Guid id);
        bool DeleteByT(Supplier t);
        bool Update(Supplier t);
        List<Supplier> GetAll();
        bool Insert(Supplier t);
        bool InsertMany(List<Supplier> t);
    }
    
    public class SupplierRepository : ISupplierRepository
    {
        private readonly BackendDbContext _context;

        public SupplierRepository(BackendDbContext context)
        {
            _context = context;
        }


        public Supplier GetById(Guid id)
        {
           return _context.Suppliers.FirstOrDefault(supplier => supplier.ID == id);
        }

        public bool DeleteById(Guid id)
        {
            _context.Suppliers.Remove(GetById(id));
            var result = Save();
            return result;
        }

        public bool DeleteByT(Supplier t)
        {
            _context.Suppliers.Remove(t);
            var result = Save();
            return result;
        }

        public bool Update(Supplier t)
        {
            _context.Suppliers.Update(t);
            var result = Save();
            return result;
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
            
        }

        public bool Insert(Supplier t)
        {
            _context.Suppliers.Add(t);
            var result = Save();
            return result;
        }

        public bool InsertMany(List<Supplier> t)
        {
            _context.Suppliers.AddRange(t);
            var result = Save();
            return result;
        }
        
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}