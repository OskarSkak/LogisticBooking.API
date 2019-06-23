using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticBooking.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticBooking.Persistence
{
    public interface IScheduleRepository
    {
        Schedule GetById(Guid id);
        bool DeleteById(Guid id);
        bool DeleteByT(Schedule t);
        bool Update(Schedule t);
        List<Schedule> GetAll();
        bool Insert(Schedule t);
        bool InsertMany(List<Schedule> t);
    }
    
    
    
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly BackendDbContext _context;

        public ScheduleRepository(BackendDbContext context)
        {
            _context = context;
        }
        
        
        public Schedule GetById(Guid id)
        {
            var result = _context.Schedules.AsNoTracking().FirstOrDefault(schedule => schedule.ScheduleId == id);
            _context.SaveChanges();
            return result;
        }

        public bool DeleteById(Guid id)
        {
            var result = _context.Schedules.Find(id);
            _context.Schedules.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteByT(Schedule t)
        {
            _context.Schedules.Remove(t);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Schedule t)
        {
            _context.Schedules.Update(t);
            _context.SaveChanges();
            return true;
        }

        public List<Schedule> GetAll()
        {
            
           var result =  _context.Schedules.Include(s => s.Intervals).ToList();
           _context.SaveChanges();
           return result;
        }

        public bool Insert(Schedule t)
        {
            
        }

        public bool InsertMany(List<Schedule> t)
        {
            throw new NotImplementedException();
        }
    }
}