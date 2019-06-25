using LogisticBooking.Infrastructure.MessagingContracts;

namespace LogisticBooking.API.Controllers
{
    public class IntervalController : BaseController
    {
        
        public IntervalController(ICommandRouter commandRouter, IQueryRouter queryRouter) : base(commandRouter, queryRouter)
        {
            
        }
        
        
    }
}