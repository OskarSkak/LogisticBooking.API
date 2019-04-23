using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.ConnectionStrings;
using LogisticBooking.Persistence.Models;

namespace LogisticBooking.Persistence.Repositories
{
    public interface ITransporterRepository : IBaseRepository<Transporter>
    {

    }

    public class TransporterRepository : BaseRepository<Transporter>, ITransporterRepository
    {
        public TransporterRepository(IConnectionString connectionString): base(connectionString)
        {

        }
    }
}
