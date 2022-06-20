using CommonService.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Repository
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, Name = "Test", Username = "test", Password = "test" ,Role = "User" },
        //    new User { Id = 1, Name = "Admin", Username = "Admin", Password = "Admin" ,Role = "Admin" }
        //};

        private readonly AppSettings _appSettings;
        private readonly LoginDbContext _context;

        public UserService(IOptions<AppSettings> appSettings, LoginDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user1 = _context.User.FirstOrDefault(x => x.Username.ToLower() == model.Username.ToLower() && x.Role.ToLower() == model.Role.ToLower());
            var user = _context.User.FirstOrDefault(x => x.Username.ToLower() == model.Username.ToLower() && x.Password == model.Password);

            // return null if user not found
            if (user1 == null) 
                return new AuthenticateResponse(new User { Username = model.Username, Role = model.Role } , "" ,  "Unauthorized Access");
            else if (user == null)
                return new AuthenticateResponse(new User { Username = model.Username, Role = model.Role }, "", "Username or Password is incorrect");
            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token ,"Success");
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User;
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToLower())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }
        public User Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user;

        }

    }
}
