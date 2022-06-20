using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonService.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public string Role { get; set; }

        public string Response { get; set; }

        public AuthenticateResponse(User user, string token,string response)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.Username;
            Role = user.Role;
            Response = response;
            Token = token;
        }
    }
}
