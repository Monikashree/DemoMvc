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

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public short Age { get; set; }

        [Required]
        public long MobileNumber { get; set; }

        [Required]
        public short SeatNo { get; set; }
       
        public int Cost { get; set; }
    }
}