using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class PassengerDetailsViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }

        public int BookingId { get; set; }
        public TicketBookingViewModel TicketBooking { get; set; }

        [Required(ErrorMessage = "PassengerName is required")]
        [RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]
        public string PassengerName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Enter Valid age")]
        public short Age { get; set; }

        [Required(ErrorMessage = "MobileNumber is required")]
        [RegularExpression("(0/91)?[6-9][0-9]{9}", ErrorMessage = "Please enter valid mobile number")]
        public long MobileNumber { get; set; }

        [Required]
        public short SeatNo { get; set; }
       
        public int Cost { get; set; }
    }
}