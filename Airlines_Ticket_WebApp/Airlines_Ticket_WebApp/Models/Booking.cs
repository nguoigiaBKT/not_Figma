using System.ComponentModel.DataAnnotations;

namespace Airlines_Ticket_WebApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public Flight Flight { get; set; }
        [Required]
        public SeatClass SeatClass { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public int SeatNumber { get; set; }
    }
}
