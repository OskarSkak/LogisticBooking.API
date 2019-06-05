using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{
    public interface ITransporterRepository : IBaseRepository<Transporter>
    {

    }

    public class TransporterRepository : BaseBackendSql<Transporter>, ITransporterRepository
    {
        public TransporterRepository(ISqlBackendConnectionString connectionString): base(connectionString)
        {

        }
    }
}
