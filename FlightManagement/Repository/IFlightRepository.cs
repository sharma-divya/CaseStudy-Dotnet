using CommonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Repository
{
    public interface IFlightRepository
    {
        void AddFlight(FlightDetails dtls);
        IQueryable GetAllFlightDetails();
       
        void DeleteFlight(int Id);
        IQueryable SearchFlights(string placefrom, string placeto);
    }
}
