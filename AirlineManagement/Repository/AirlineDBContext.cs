using CommonService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Repository
{
    public class AirlineDBContext : DbContext
    {

        public AirlineDBContext(DbContextOptions<AirlineDBContext> options) : base(options)
        {

        }
        public DbSet<AirlineDetails> AirlineDetails { get; set; }

    }
}
