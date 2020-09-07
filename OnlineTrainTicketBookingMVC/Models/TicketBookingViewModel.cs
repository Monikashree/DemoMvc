using OnlineTrainTicketBookingApp.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class TicketBookingViewModel     //Attributes of Ticket booking with key constraints
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }

        public int TrainId { get; set; }
        public TrainDetailsViewModel TrainDetails { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public int NoOfPassengers { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime JourneyDate { get; set; }


        [Required]
        //[Column(TypeName = "time")]
        public DateTime BookingTime { get; set; }
    }
}