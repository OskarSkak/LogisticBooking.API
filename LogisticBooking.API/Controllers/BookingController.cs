﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticBooking.API.RequestModels;
using LogisticBooking.Documents.Documents;
using LogisticBooking.Domain.Commands;
using LogisticBooking.Domain.Commands.Booking;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Queries.Queries;
using LogisticBooking.Queries.Queries.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LogisticBooking.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : BaseController
    {
        public BookingController(ICommandRouter commandRouter, IQueryRouter queryRouter) : base(commandRouter,
            queryRouter)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBooking([FromBody] BookingRequestModel bookingRequestModel)
        {
            
           var loggedIn = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            Guid LoggedInID = new Guid(loggedIn);
            List<Order> orders = new List<Order>();

            foreach (var order in bookingRequestModel.OrderViewModels)
            {
               orders.Add(new Order
               {
                   bookingId = order.bookingId,
                   customerNumber = order.customerNumber,
                   wareNumber = order.wareNumber,
                   orderNumber = order.orderNumber,
                   InOut = order.InOut
               }); 
            }
            
            var result = await CommandRouter.RouteAsync<CreateBookingCommand, IdResponse>(
                new CreateBookingCommand(bookingRequestModel.totalPallets, bookingRequestModel.bookingTime,
                    bookingRequestModel.transporterName, bookingRequestModel.port, bookingRequestModel.actualArrival,
                    bookingRequestModel.startLoading, bookingRequestModel.endLoading, bookingRequestModel.email , orders ,LoggedInID, bookingRequestModel.ExternalId ));
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var result = await QueryRouter.QueryAsync<BookingsQuery, IList<Booking>>(new BookingsQuery());
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var result = await QueryRouter.QueryAsync<GetBookingById, Booking>(new GetBookingById(id));
            var orders = await QueryRouter.QueryAsync<OrdersQuery, IList<Order>>(new OrdersQuery());
            var ordersWithBookingId = new List<Order>();

            foreach (var order in orders)
            {
                if(order.bookingId == result.internalId) ordersWithBookingId.Add(order);
            }

            result.Orders = ordersWithBookingId;
            
            return new ObjectResult(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBookingById(Guid id)
        {
            var result = await CommandRouter.RouteAsync<DeleteBookingCommand, IdResponse>(new DeleteBookingCommand(id));
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingRequestModel bookingRequestModel, Guid id)
        {
            var booking = await QueryRouter.QueryAsync<GetBookingById, Booking>(new GetBookingById(id));

            if (booking != null)
            {
                if (bookingRequestModel.totalPallets == 0)
                    bookingRequestModel.totalPallets = booking.totalPallets;
                if (DateTimeEmpty(bookingRequestModel.bookingTime))
                    bookingRequestModel.bookingTime = booking.bookingTime;
                if (String.IsNullOrEmpty(bookingRequestModel.transporterName))
                    bookingRequestModel.transporterName = booking.transporterName;
                if (bookingRequestModel.port == 0)
                    bookingRequestModel.port = booking.port;
                if (DateTimeEmpty(bookingRequestModel.actualArrival))
                    bookingRequestModel.actualArrival = booking.actualArrival;
                if (DateTimeEmpty(bookingRequestModel.startLoading))
                    bookingRequestModel.startLoading = booking.startLoading;
                if (DateTimeEmpty(bookingRequestModel.endLoading))
                    bookingRequestModel.endLoading = booking.endLoading;
                if (String.IsNullOrEmpty(bookingRequestModel.email))
                    bookingRequestModel.email = booking.email;
                if (bookingRequestModel.ExternalId == 0)
                {
                    bookingRequestModel.ExternalId = booking.ExternalId; 
                }
            }

            var result = await CommandRouter.RouteAsync<UpdateBookingCommand, IdResponse>(
                new UpdateBookingCommand(bookingRequestModel.totalPallets, bookingRequestModel.bookingTime,
                    bookingRequestModel.transporterName, bookingRequestModel.port, bookingRequestModel.actualArrival,
                    bookingRequestModel.startLoading, bookingRequestModel.endLoading, bookingRequestModel.email, id , bookingRequestModel.ExternalId));
            return !result.IsSuccessful ? Conflict(result) : new ObjectResult(result);
        }

        public static bool DateTimeEmpty(DateTime dateTime)
        {
            return dateTime == default(DateTime);
        }
    }
}
