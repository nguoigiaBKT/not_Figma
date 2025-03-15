using System.ComponentModel.DataAnnotations;

namespace Booking_Airline.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        public string Destination_City { get; set; }
        public string Destination_Airport { get; set; }
    }
}
