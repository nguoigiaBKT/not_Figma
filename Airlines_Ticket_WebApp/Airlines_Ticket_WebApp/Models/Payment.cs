using System;
using System.ComponentModel.DataAnnotations;

namespace Airlines_Ticket_WebApp.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100)]
        public string CardHolderName { get; set; }

        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(5)]
        public string ExpiryDate { get; set; }

        [Required]
        [StringLength(3)]
        public string CVV { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = "Credit Card";

        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; } = "Completed";

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public bool UseContactAddress { get; set; }

        // Navigation property
        public virtual Booking Booking { get; set; }
    }
}