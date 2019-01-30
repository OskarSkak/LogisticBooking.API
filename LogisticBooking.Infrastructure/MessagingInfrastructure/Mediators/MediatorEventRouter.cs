using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Infrastructure.MessagingContracts;
using SimpleSoft.Mediator;

namespace LogisticBooking.Infrastructure.MessagingInfrastructure.Mediators {
    public class MediatorEventRouter : IEventRouter {
        
        private readonly IMediator _mediator;

        public MediatorEventRouter (IMediator mediator)
        {
            _mediator = mediator;
        }
        

        public async Task EventAsync<TEvent> (TEvent query, CancellationToken cancellationToken = default (CancellationToken)) where TEvent : IEvent
        {
            await _mediator.BroadcastAsync(query, cancellationToken);
        }
    }
}