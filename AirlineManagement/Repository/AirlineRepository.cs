using CommonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Repository
{
    public class AirlineRepository : IAirlineRepository
    {

        private readonly AirlineDBContext _context;

        public AirlineRepository(AirlineDBContext context)
        {
            this._context = context;
        }
        public void AddAirline(AirlineDetails dtls)
        {
            _context.AirlineDetails.Add(dtls);
            _context.SaveChanges();
        }
        public IEnumerable<AirlineDetails> GetAllAirlines()
        {
            return _context.AirlineDetails.ToList();
        }

        public void DeleteAirline(int Id)
        {
            AirlineDetails dtl = _context.AirlineDetails.FirstOrDefault(x => x.AirlineId == Id);
            _context.AirlineDetails.Remove(dtl);
            _context.SaveChanges();
        }


       
    }
}
