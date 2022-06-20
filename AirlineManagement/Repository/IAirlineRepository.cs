using CommonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Repository
{
    public interface IAirlineRepository
    {
        void AddAirline(AirlineDetails dtls);

        IEnumerable<AirlineDetails> GetAllAirlines();

      
        void DeleteAirline(int Id);
    }
}
