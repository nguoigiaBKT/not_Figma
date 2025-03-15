using System.ComponentModel.DataAnnotations;

namespace Booking_Airline.Models
{
    public class Origin
    {
        [Key]
        public int Id { get; set; }
        public string Origin_City { get; set; }
        public string Origin_Airport { get; set; }
    }
}
