using System.Threading;
using System.Threading.Tasks;
using SimpleSoft.Mediator;

namespace LogisticBooking.Infrastructure.MessagingContracts
{
    public interface IEventRouter
    {
        Task EventAsync<TEvent>(TEvent query, CancellationToken cancellationToken = default(CancellationToken))
            where TEvent : IEvent;
    }
}