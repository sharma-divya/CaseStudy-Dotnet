using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public string Password { get; set; }

        public ICollection<BookingDetails> bookings { get; set; }
    }
}
