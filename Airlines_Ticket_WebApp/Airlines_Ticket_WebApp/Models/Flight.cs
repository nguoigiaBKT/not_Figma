using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airlines_Ticket_WebApp.Models
{
    public class Flight
    {
        [Key] // Đánh dấu khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tạo giá trị
        public int FlightId { get; set; }

        [Required]
        public string Airline { get; set; }

        [Required]
        public string Departure { get; set; } // Có thể đổi tên thành DepartureAirport

        [Required]
        public Origin Origin { get; set; } // Sử dụng string để lưu tên sân bay hoặc thành phố

        [Required]
        public Destination Destination { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; } // Sử dụng DateTime thay vì string

        public DateTime? ArrivalTime { get; set; } // Cho phép null nếu không cần thiết

        [Required]
        [EnumDataType(typeof(FlightStatus))]
        public FlightStatus Status { get; set; } = FlightStatus.Scheduled; // Trạng thái chuyến bay
    }

    public enum FlightStatus
    {
        Scheduled,
        Delayed,
        Cancelled,
        Completed
    }
}
