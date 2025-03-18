using Booking_Airline.Models;
using Microsoft.EntityFrameworkCore;

namespace Airlines_Ticket_WebApp.Models
{
    public class FlightDBContext : DbContext
    {
        public FlightDBContext(DbContextOptions<FlightDBContext> options) : base(options)
        {
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<SeatClass> SeatClasses { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
