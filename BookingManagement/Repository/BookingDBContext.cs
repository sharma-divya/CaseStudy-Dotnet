using CommonService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public class BookingDBContext : DbContext
    {
        public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options)
        {

        }
        public DbSet<BookingDetails> BookingDetails { get; set; }

        public DbSet<FlightDetails> FlightDetails { get; set; }
        public DbSet<AirlineDetails> AirlineDetails { get; set; }
        public DbSet<PassengerDetails> PassengerDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<BookingDetails>().HasOne<FlightDetails>(e => e.Flight)
                .WithMany(d => d.Bookings).HasForeignKey(e => e.FlightId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            model.Entity<BookingDetails>().HasMany<PassengerDetails>(e=>e.PassengerDetails)
                .WithOne(d=>d.BookingDetails).HasForeignKey(e=>e.BookingId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            //model.Entity<BookingDetails>().HasOne<User>(e => e.User)
            // .WithMany(d => d.bookings).HasForeignKey(e => e.UserId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(model);
        }

    }
}
