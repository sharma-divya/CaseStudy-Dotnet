using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommonService.Models
{

    public class BookingDetails
    {
        [Key]
        public int BookingId { get; set; }

        public string Name { get; set; }


        public string Email { get; set; }


        [ForeignKey("Id")]
        public int Id { get; set; }

        public virtual User User { get; set; }


        public int NoofSeats { get; set; }
        public int? PNR { get; set; }

        [ForeignKey("FlightId")]
        public int FlightId { get; set; }

        public virtual FlightDetails Flight { get; set; }

       public ICollection<PassengerDetails> PassengerDetails { get; set; }
      
    }


    public class PassengerDetails
    {
        [Key]
        public int PassengerId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }
        public virtual BookingDetails BookingDetails { get; set; }
        public string PassengerName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public string Meal { get; set; }

        public string SeatClass { get; set; }

    }

    //public enum SeatClass { 
    //   Business,
    //   NonBusiness
    //}

    public class TicketDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int NoofSeats { get; set; }
        public int PNR { get; set; }

        public string FlightNo { get; set; }

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public string PlaceFrom { get; set; }

        public string PlaceTo { get; set; }

        public double TicketPrice { get; set; }

    }
}
