using CommonService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public class SQLBookingRepository : IBookingRepository
    {
        private readonly BookingDBContext _context;

        public SQLBookingRepository(BookingDBContext context)
        {
            this._context = context;
        }

        public int AddBooking(BookingDetails dtls)
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            dtls.PNR = myRandomNo;
            _context.BookingDetails.Add(dtls);
            _context.SaveChanges();
            return myRandomNo;
        }

        public void CancelBooking(int id)
        {
            BookingDetails dtl = _context.BookingDetails.FirstOrDefault(x => x.BookingId == id);
            _context.BookingDetails.Remove(dtl);
            _context.SaveChanges();
        }

        public IQueryable GetBookingsFromEmail(string Email)
        {
            var result = (from book in _context.BookingDetails.AsQueryable()
                          join flight in _context.FlightDetails.AsQueryable()
                          on book.FlightId equals flight.FlightId
                          join airline in _context.AirlineDetails.AsQueryable()
                          on flight.AirlineId equals airline.AirlineId
                          where book.Email.ToLower().Trim() == Email.ToLower().Trim()
                          select new 
                          {
                            AirlineName = airline.AirlineName
                            ,  BookingId = book.BookingId
                           ,   Name = book.Name
                          ,
                              Email = book.Email
                          ,
                              FlightNo = flight.FlightNo
                          ,
                              PlaceFrom = flight.PlaceFrom
                          ,
                              PlaceTo = flight.PlaceTo
                          ,
                              TicketPrice = flight.TicketPrice
                          ,
                              StartDateTime = flight.StartDateTime
                          ,
                              EndDateTime = flight.EndDateTime
                               ,
                              ScheduleDays = flight.ScheduleDays
                          });
            return result;
        }

        public IQueryable GetBookingFromPNR(string PNR)
        {
            var result = (from book in _context.BookingDetails.AsQueryable()
                          join flight in _context.FlightDetails.AsQueryable()
                          on book.FlightId equals flight.FlightId
                          join airline in _context.AirlineDetails.AsQueryable()
                          on flight.AirlineId equals airline.AirlineId                         
                          where book.PNR.ToString().Trim() == PNR.Trim()
                          select new
                          {
                              AirlineName = airline.AirlineName
                            ,
                              BookingId = book.BookingId
                           ,
                              Name = book.Name
                          ,
                              Email = book.Email
                          ,
                              FlightNo = flight.FlightNo
                          ,
                              PlaceFrom = flight.PlaceFrom
                          ,
                              PlaceTo = flight.PlaceTo
                          ,
                              TicketPrice = flight.TicketPrice
                          ,
                              StartDateTime = flight.StartDateTime
                          ,
                              EndDateTime = flight.EndDateTime
                               ,
                              ScheduleDays = flight.ScheduleDays
                          });
            return result;

        }
        



    }
}
