using System.Threading.Tasks;

namespace LogisticBooking.Persistence.BaseRepository
{
    public interface IBaseSqlRepository<T> where T : class
    {
        Task<object> InsertAsync(T value);
    }
}