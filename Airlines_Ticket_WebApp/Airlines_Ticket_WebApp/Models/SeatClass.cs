using System.ComponentModel.DataAnnotations;

namespace Airlines_Ticket_WebApp.Models
{
    public class SeatClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public decimal PriceMultiplier { get; set; }
    }
}
