using System.Threading;
using System.Threading.Tasks;
using SimpleSoft.Mediator;

namespace LogisticBooking.Infrastructure.MessagingContracts
{
    public interface IQueryRouter
    {
        Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default(CancellationToken))
            where TQuery : IQuery<TResult>;
    }
}