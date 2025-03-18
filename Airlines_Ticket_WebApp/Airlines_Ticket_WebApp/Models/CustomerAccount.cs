using System;
using System.ComponentModel.DataAnnotations;

namespace Airlines_Ticket_WebApp.Models
{
    public class CustomerAccount
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
} 