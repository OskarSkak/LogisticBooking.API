using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dommel;
using LogisticBooking.Persistence.ConnectionStrings;

namespace LogisticBooking.Persistence.BaseRepository
{
    public class BaseBackendSql<T> : IBaseRepository<T> where T : class
    {
         
        //************************** PROPERTIES ******************************************
        private readonly ISqlBackendConnectionString _connectionString;
        
        
        
        
        //*************************** CONSTRUCTOR ****************************************

        public BaseBackendSql(ISqlBackendConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        
        
        
        public async Task<object> InsertAsync(T value)
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                
                var result = await conn.InsertAsync(value);
                conn.Close();
                return result;
            }
        }

        public async Task<object> InsertManyAsync(IEnumerable<T> valueList)
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var result = await conn.InsertAsync(valueList);
                conn.Close();
                return result;
            }
            
        }

        public async Task<bool> UpdateAsync(T value)
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var result = await conn.UpdateAsync(value);
                
                conn.Close();
                return result;

            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var result = await conn.GetAsync<T>(id);
                conn.Close();
                return result;

            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var result = await conn.GetAllAsync<T>();
                conn.Close();
                return result;

            }
        }

        public async Task<bool> DeleteByTAsync(T value)
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                var result = await conn.DeleteAsync(value);
                conn.Close();
                return result;
            }
        }

    }
}