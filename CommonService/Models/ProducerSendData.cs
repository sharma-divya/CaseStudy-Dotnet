using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonService.Models
{
    public class ProducerSendData
    {
        public int FlightId { get; set; }
        public int BusinessSeats { get; set; }
        public int NonBusinessSeats { get; set; }

        //Total no. of seats
        public int Rows { get; set; }
    }
}
