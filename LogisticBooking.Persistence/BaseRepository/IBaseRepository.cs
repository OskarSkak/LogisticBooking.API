using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogisticBooking.Persistence.BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        ///
        /// Insert an object to a database
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Affected rows</returns>
        Task<object> InsertAsync(T value);
        
        /// <summary>
        ///
        /// Insert a list of objects to a database
        /// </summary>
        /// <param name="valueList"></param>
        /// <returns>Affected rows</returns>
        Task<object> InsertManyAsync(IEnumerable<T> valueList);
        
        
        /// <summary>
        ///
        /// Update a specific object in the database based on the primary key
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if the object is updated</returns>
        Task<bool> UpdateAsync(T value);
        
        
        /// <summary>
        /// Get an object from the DB based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The object that matches the id</returns>
        Task<T> GetByIdAsync(Guid id);


        /// <summary>
        /// Get all objects from at table
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns>A list og objects</returns>
        Task<IEnumerable<T>> GetAllAsync();

        
        /// <summary>
        ///
        /// Delete an object from the db 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if the object is deleted</returns>
        Task<bool> DeleteByTAsync(T value);
        
    }
       
}