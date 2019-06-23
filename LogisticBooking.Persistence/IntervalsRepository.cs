using System;
using System.Collections.Generic;
using System.Linq;
using LogisticBooking.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticBooking.Persistence
{
    public interface IIntervalsRepository
    {
        Interval GetById(Guid id);
        bool DeleteById(Guid id);
        bool DeleteByT(Interval t);
        bool Update(Interval t);
        List<Interval> GetAll();
        bool Insert(Interval t);
        bool InsertMany(List<Interval> t);
    }
    
    
    
    public class IntervalsRepository : IIntervalsRepository
    {
        private readonly BackendDbContext _context;

        public IntervalsRepository(BackendDbContext context)
        {
            _context = context;
        }

        public Interval GetById(Guid id)
        {
            var result = _context.Intervals.AsNoTracking().FirstOrDefault(Interval => Interval.IntervalId == id);
            _context.SaveChanges();
            return result;
        }

        public bool DeleteById(Guid id)
        {
            var result = _context.Intervals.Find(id);
            _context.Intervals.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteByT(Interval t)
        {
            _context.Intervals.Remove(t);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Interval t)
        {
            _context.Intervals.Update(t);
            _context.SaveChanges();
            return true;
        }

        public List<Interval> GetAll()
        {
            return _context.Intervals.AsNoTracking().ToList();
           
        }

        public bool Insert(Interval t)
        {
            _context.Intervals.Add(t);
            _context.SaveChanges();
            return true;
        }

        public bool InsertMany(List<Interval> t)
        {
            _context.Intervals.AddRange(t);
            _context.SaveChanges();
            return true;
        }
    }
}