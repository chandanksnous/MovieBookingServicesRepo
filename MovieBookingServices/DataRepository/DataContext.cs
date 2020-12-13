using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBooking.Models;

namespace MovieBooking.Data
{
    public class DataContext :DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MovieVenueInfo> MovieVenueInfo { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CustomersTicketBookingHistory> CustomersTicketBookingHistory { get; set; }
    }
}
