using CommonService.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Repository
{
    public class SQLFlightRepository : IFlightRepository , IConsumer<ProducerSendData>
    {
        private readonly FlightDBContext _context;
       
        public SQLFlightRepository(FlightDBContext context)
        {
            this._context = context;
        }
        public async Task Consume(ConsumeContext<ProducerSendData> context)
        {
            int FlightId = context.Message.FlightId;
            var table = _context.FlightDetails.Find(FlightId);
            table.Rows = table.Rows - context.Message.Rows;
            table.BusinessClassSeats = table.BusinessClassSeats - context.Message.BusinessSeats;
            table.NonBusinessClassSeats = table.NonBusinessClassSeats - context.Message.NonBusinessSeats;
            _context.Entry(table).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public void AddFlight(FlightDetails dtls)
        {
            try
            {

                _context.FlightDetails.Add(dtls);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable GetAllFlightDetails()
        {
            try
            {
                var result = (from flight in _context.FlightDetails.AsQueryable()
                              join airline in _context.AirlineDetails.AsQueryable()
                              on flight.AirlineId equals airline.AirlineId
                              select new 
                              {
                                  flight.FlightId,
                                  flight.FlightNo,
                                  flight.StartDateTime,
                                  flight.EndDateTime,
                                  flight.PlaceFrom ,
                                  flight.PlaceTo ,
                                  flight.BusinessClassSeats, 
                                  flight.NonBusinessClassSeats,
                                  flight.TicketPrice ,
                                  flight.Meal,
                                  flight.ScheduleDays,
                                  flight.InstrumentUsed,
                                  flight.Rows,
                                  airline.AirlineName
                              });
                return result;

              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public void DeleteFlight(int Id)
        {
            try
            {
                FlightDetails dtl = _context.FlightDetails.FirstOrDefault(x => x.FlightId == Id);
                _context.FlightDetails.Remove(dtl);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IQueryable SearchFlights(string placefrom, string placeto)
        {
            try
            {
                var res = (from flight in _context.FlightDetails.Where(x => x.PlaceFrom.ToLower() == placefrom.ToLower() && x.PlaceTo.ToLower() == placeto.ToLower()).AsQueryable()
                join airline in _context.AirlineDetails.AsQueryable()
                              on flight.AirlineId equals airline.AirlineId
                              select new
                              {
                                  flight.FlightId,
                                  flight.FlightNo,
                                  flight.StartDateTime,
                                  flight.EndDateTime,
                                  flight.PlaceFrom,
                                  flight.PlaceTo,
                                  flight.BusinessClassSeats,
                                  flight.NonBusinessClassSeats,
                                  flight.TicketPrice,
                                  flight.Meal,
                                  flight.ScheduleDays,
                                  flight.InstrumentUsed,
                                  flight.Rows,
                                  airline.AirlineName
                              });
                
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
    }
}
