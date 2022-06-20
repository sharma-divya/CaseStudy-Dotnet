using CommonService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Repository
{
    public class FlightDBContext : DbContext
    {
        public FlightDBContext(DbContextOptions<FlightDBContext> options) : base(options)
        {

        }
        public DbSet<FlightDetails> FlightDetails { get; set; }
        public DbSet<AirlineDetails> AirlineDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<FlightDetails>().HasOne<AirlineDetails>(e => e.Airlines)
                .WithMany(d => d.Flights).HasForeignKey(e => e.AirlineId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(model);
        }
    }
}
