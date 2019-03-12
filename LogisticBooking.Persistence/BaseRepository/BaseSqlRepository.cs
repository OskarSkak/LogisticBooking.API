using System.Data.SqlClient;
using System.Threading.Tasks;
using Dommel;
using LogisticBooking.Persistence.ConnectionStrings;

namespace LogisticBooking.Persistence.BaseRepository
{
    public class BaseSqlRepository<T> : IBaseSqlRepository<T> where T : class
    {
        private readonly ISqlConnectionString _connectionString;

        public BaseSqlRepository(ISqlConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        
        
        public async Task<object> InsertAsync(T value)
        {
            using (var conn = new SqlConnection(_connectionString.ConnectionString))
            {
                conn.Open();
                
                var result = await conn.InsertAsync(value);
                return result;
            }
        }
    }
}