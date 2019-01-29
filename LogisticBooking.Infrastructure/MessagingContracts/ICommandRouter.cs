using System.Threading;
using System.Threading.Tasks;
using SimpleSoft.Mediator;

namespace LogisticBooking.Infrastructure.MessagingContracts
{
    public interface ICommandRouter
    {
        Task<TResponse> RouteAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default(CancellationToken)) where TCommand : ICommand<TResponse>;
    }
}