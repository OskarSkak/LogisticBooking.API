using LogisticBooking.Infrastructure.MessagingContracts;
using Microsoft.AspNetCore.Mvc;

namespace LogisticBooking.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ICommandRouter CommandRouter;
        protected readonly IQueryRouter QueryRouter;

        public BaseController(ICommandRouter commandRouter , IQueryRouter queryRouter)
        {
            this.CommandRouter = commandRouter;
            this.QueryRouter = queryRouter;
        }
    }
}