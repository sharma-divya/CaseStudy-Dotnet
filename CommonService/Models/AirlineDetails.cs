using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommonService.Models
{
    public class AirlineDetails
    {
        [Key]
        public int AirlineId { get; set; }

        public string AirlineName { get; set; }

        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }

        public string DiscountCode { get; set; }

        public double? DiscountAmount { get; set; }

        public string Logo { get; set; }

        public int? Status { get; set; } // block(0) or running(1)

       public virtual ICollection<FlightDetails> Flights { get; set; }
    }
}
