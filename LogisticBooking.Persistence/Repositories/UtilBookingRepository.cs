using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{
    public interface IUtilBookingRepository : IBaseRepository<UtilBooking>
    {
        Task<Object> UpdateUtil(UtilBooking utilBooking);
    }


    public class UtilBookingRepository : BaseBackendSql<UtilBooking>, IUtilBookingRepository
    {
        public ISqlBackendConnectionString ConnectionString { get; set; }

        public UtilBookingRepository(ISqlBackendConnectionString connectionString) : base(connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<Object> UpdateUtil(UtilBooking utilBooking)
        {
            var sql = "Update dbo.utilbooking set utilbooking.bookingid = utilbooking.bookingid + 1 ";


            using (var conn = new SqlConnection(ConnectionString.ConnectionString))
            {
                conn.Open();
                var utilBookingUpdated = conn.Query(sql);
                
                return utilBookingUpdated;
            }
        }
    }
}