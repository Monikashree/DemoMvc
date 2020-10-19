using OnlineTrainTicketBookingMVC;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingApp.Entity
{
    public class TicketBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       //Attributes of ticket booking with key constraints
        public int BookingId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TrainId { get; set; }
        public TrainDetails TrainDetails { get; set; }

        [Required]
        public int ClassId { get; set; }


        [Required]
        public int NoOfPassengers { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime JourneyDate { get; set; }


        [Required]
        public DateTime BookingTime { get; set; }
    }
}
