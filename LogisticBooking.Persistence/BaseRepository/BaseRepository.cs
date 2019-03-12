using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dommel;
using LogisticBooking.Persistence.ConnectionStrings;
using Npgsql;

namespace LogisticBooking.Persistence.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IConnectionString _connectionString;

        public BaseRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<object> InsertAsync(T value)
        {
            using (var conn = new NpgsqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();


                var a = await conn.InsertAsync(value);
                return a;
            }
        }


        public async Task<object> InsertManyAsync(IEnumerable<T> valueList)
        {
            using (var conn = new NpgsqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();

                
                var a = await conn.InsertAsync(valueList);
                return a as T;
            }
        }
    //***********************UPDATE ***************************

        public async Task<bool> UpdateAsync(T value)
        {
            using (var conn = new NpgsqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();

                return await conn.UpdateAsync(value);
            }
        }
    //***********************GET ***************************

        public async Task<T> GetByIdAsync(Guid id)
        {
            
            
            using (var conn = new NpgsqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();

                var result = await conn.GetAsync<T>(id);
                return result;

            }
        }

        public async Task<IEnumerable<T>> GetAllAsync() 
        {
            using (var conn = new NpgsqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();

                return await conn.GetAllAsync<T>();
            }
        }

        
    //***********************DELETE ***************************

        public async Task<bool> DeleteByTAsync(T value)
        {
            if (value.Equals(null))
            {
                return false;
            }
            
            using (var conn = new NpgsqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();

                var result = await conn.DeleteAsync(value);
                return result;
            }
        }

       

    }
}