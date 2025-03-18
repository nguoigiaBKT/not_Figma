using System.ComponentModel.DataAnnotations;

namespace Airlines_Ticket_WebApp    .Models
{
    public class Origin
    {
        [Key]
        public int Id { get; set; }
        public string Origin_City { get; set; }
        public string Origin_Airport { get; set; }
    }
}
