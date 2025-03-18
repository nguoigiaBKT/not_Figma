using System;
using System.ComponentModel.DataAnnotations;

namespace Airlines_Ticket_WebApp.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string Airline { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Departure { get; set; }

        [Required]
        public string Arrival { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public string BookingId { get; set; }

        [Required]
        public string AirlineBookingCode { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}
