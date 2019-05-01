using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries.Util;
using Microsoft.AspNetCore.Mvc;

namespace LogisticBooking.API.Controllers
{
    
    [Route ("api/utilbooking")]
    [ApiController]
    public class UtilBookingController : BaseController
    {
        public UtilBookingController(ICommandRouter commandRouter, IQueryRouter queryRouter) : base(commandRouter , queryRouter)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetUtilBookingId()
        {
            var result = await QueryRouter.QueryAsync<UtilBookingQuery , UtilBooking>(new UtilBookingQuery());

            Console.WriteLine(result);
            
            return new ObjectResult(result);
        }
    }
}