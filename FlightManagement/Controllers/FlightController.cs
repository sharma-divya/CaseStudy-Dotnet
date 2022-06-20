using CommonService.Models;
using FlightManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        
        private IFlightRepository _flight;
        public FlightController(IFlightRepository flight)
        {
            _flight = flight;
        }
      

        [HttpGet]
        [Route("GetAllFlights")]
        [Authorize(Roles = "admin")]
        public IQueryable GetAllFlights()
        {
            return _flight.GetAllFlightDetails();
        }
       
        // POST api/<AirlinesController>
        [HttpPost]
        [Route("AddFlight")]
        [Authorize(Roles = "admin")]
        public void AddFlight([FromBody] FlightDetails flight)
        {
            _flight.AddFlight(flight);
        }

        // DELETE api/<FlightController>/5
        [HttpDelete]
        [Route("DeleteFlight")]
        [Authorize(Roles = "admin")]
        public void DeleteFlight(int id)
        {
             _flight.DeleteFlight(id);
        }

        [HttpGet]
        [Route("SearchFlights")]
        [Authorize(Roles = "admin,user")]
        public IQueryable SearchFlights(string placefrom, string placeto)
        {
            return _flight.SearchFlights(placefrom,placeto);
        }
    }
}
