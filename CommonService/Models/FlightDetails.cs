using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommonService.Models
{
    public class FlightDetails
    {
        [Key]
        public int FlightId { get; set; }

        public string FlightNo { get; set; }

        [ForeignKey("AirlineId")]
        public int AirlineId { get; set; }

        public virtual AirlineDetails Airlines { get; set; }

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public string PlaceFrom { get; set; }

        public string PlaceTo { get; set; }

        public int BusinessClassSeats { get; set; }

        public int NonBusinessClassSeats { get; set; }

        public double TicketPrice { get; set; }

        //Rows are Seats only
        public int Rows { get; set; }

        public string Meal { get; set; }

        public string ScheduleDays { get; set; }
        public string InstrumentUsed { get; set; }

        public virtual ICollection<BookingDetails> Bookings { get; set; }

    }
}
