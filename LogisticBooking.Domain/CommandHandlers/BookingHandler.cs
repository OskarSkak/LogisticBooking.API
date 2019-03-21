using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands.Booking;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using SimpleSoft.Mediator;

namespace LogisticBooking.Domain.CommandHandlers
{
    public class BookingHandler : ICommandHandler<CreateBookingCommand, IdResponse>,
        ICommandHandler<DeleteBookingCommand, IdResponse>,
        ICommandHandler<UpdateBookingCommand, IdResponse>

    {
        private readonly IEventRouter _eventRouter;
        private readonly IBookingRepository _bookingRepository;

        public BookingHandler(IBookingRepository bookingRepository, IEventRouter eventRouter)
        {
            _bookingRepository = bookingRepository;
            _eventRouter = eventRouter;
        }
        
        public async Task<IdResponse> HandleAsync(CreateBookingCommand cmd, CancellationToken ct)
        {
            var result = await _bookingRepository.InsertAsync(new Booking
            {
                internalId = cmd.internalId,
                email = cmd.email,
                endLoading = cmd.endLoading,
                startLoading = cmd.startLoading,
                totalPallets = cmd.totalPallets,
                actualArrival = cmd.actualArrival,
                transporterName = cmd.transporterName,
                bookingTime = cmd.bookingTime,
                port = cmd.port
            }); 
            return new IdResponse(cmd.Id);
        }

        public async Task<IdResponse> HandleAsync(DeleteBookingCommand cmd, CancellationToken ct)
        {
            var booking = await _bookingRepository.GetByIdAsync(cmd.id);
            var result = await _bookingRepository.DeleteByTAsync(booking);
            return new IdResponse(cmd.id);
        }

        public async Task<IdResponse> HandleAsync(UpdateBookingCommand cmd, CancellationToken ct)
        {
            var result = await _bookingRepository.UpdateAsync(new Booking
            {
                email = cmd.email,
                actualArrival = cmd.actualArrival,
                bookingTime = cmd.bookingTime,
                endLoading = cmd.endLoading,
                port = cmd.port,
                internalId = cmd.internalId,
                startLoading = cmd.startLoading,
                totalPallets = cmd.totalPallets,
                transporterName = cmd.transporterName
            });
            return new IdResponse(cmd.Id);
        }
    }
}