using AirlineManagement.Repository;
using CommonService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlineManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize(Roles = "admin")]
    public class AirlineController : ControllerBase
    {
        private IAirlineRepository _airl;
        public AirlineController(IAirlineRepository airl)
        {
            _airl = airl;
        }

        // GET: api/<AirlinesController>
        [HttpGet]
        [Route("GetAllAirline")]
        public IEnumerable<AirlineDetails> GetAllAirline()
        {
            return _airl.GetAllAirlines();
        }
      
       
        // POST api/<AirlinesController>
        [HttpPost]
        [Route("AddAirline")]
        public void AddAirline([FromBody] AirlineDetails airl)
        {
            _airl.AddAirline(airl);
        }


        // DELETE api/<AirlineController>/5
        [HttpDelete]
        [Route("Block")]
        public void Delete(int id)
        {
            _airl.DeleteAirline(id);
        }
    }
}
