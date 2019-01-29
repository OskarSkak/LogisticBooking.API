using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Infrastructure.MessagingContracts;
using SimpleSoft.Mediator;

namespace LogisticBooking.Infrastructure.MessagingInfrastructure.Mediators
{
    public class MediatorQueryRouter : IQueryRouter
    {
        private readonly IMediator mediator;

        public MediatorQueryRouter(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default(CancellationToken)) where TQuery : IQuery<TResult>
        {
            return await mediator.FetchAsync<TQuery, TResult>(query, cancellationToken);
        }
    }
}