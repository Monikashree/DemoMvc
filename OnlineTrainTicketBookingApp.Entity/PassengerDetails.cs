using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingApp.Entity
{
    public class PassengerDetails                               //Attributes of passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassengerId { get; set; }

        public int BookingId { get; set; }
        public TicketBooking TicketBooking { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public short Age { get; set; }

        [Required]
        public long MobileNumber { get; set; }

        //[Required]
        //public string ClassName { get; set; }

        [Required]
        public short SeatNo { get; set; }

        [Required]
        public int Cost { get; set; }
    }
}
