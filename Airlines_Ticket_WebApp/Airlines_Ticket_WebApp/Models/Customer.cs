using System.ComponentModel.DataAnnotations;

namespace Booking_Airline.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Customer_Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Customer Email")]
        public string Customer_Email { get; set; }

        [Phone]
        [Display(Name = "Customer Phone")]
        public string Customer_Phone { get; set; }

        [Display(Name = "Customer Address")]
        public string Customer_Address { get; set; }
    }
}
