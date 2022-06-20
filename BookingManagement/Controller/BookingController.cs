using BookingManagement.Repository;
using CommonService.Models;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    public class BookingController : ControllerBase
    {

        private IBookingRepository _booking;
        private readonly IBus _bus;
        public BookingController(IBookingRepository booking, IBus bus)
        {
            _booking = booking;
            _bus = bus;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("GetBookingFromPNR")]
        public IQueryable GetBookingFromPNR(string PNR)
        {
            return _booking.GetBookingFromPNR(PNR);
        }
        [HttpGet]
        [Route("GetBookingsFromEmail")]
        public IQueryable GetBookingsFromEmail(string Email)
        {
            return _booking.GetBookingsFromEmail(Email);
        }

        [HttpPost]
        [Route("AddBooking")]
        public async Task<int> AddBooking([FromBody] BookingDetails booking)
        {
           int myRandomNo =  _booking.AddBooking(booking);
            int BusinessClassSeats =  booking.PassengerDetails.Where(x => x.SeatClass.ToLower() == "business").Count();
            int NonbusinessClassSeats = booking.PassengerDetails.Where(x => x.SeatClass.ToLower() == "nonbusiness").Count();
            Uri uri = new Uri("rabbitmq://localhost/InventoryQueue");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(new ProducerSendData {
                BusinessSeats = BusinessClassSeats, 
                NonBusinessSeats = NonbusinessClassSeats,FlightId = booking.FlightId, Rows = booking.NoofSeats } );
            return myRandomNo;
        }

       
        [HttpDelete]
        [Route("CancelBooking")]
        public void CancelBooking(int id)
        {
            _booking.CancelBooking(id);
        }

    }
}
