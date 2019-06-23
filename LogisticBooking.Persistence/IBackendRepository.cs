using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogisticBooking.Persistence
{
    public interface IBackendRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task DeleteByTEntity(T Entity);
        Task<T> DeleteById(T Entity);
        Task<T> Update(T Entity);
        Task Insert(T Entity);
        

    }
}