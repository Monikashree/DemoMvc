using OnlineTrainTicketBookingMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingApp.Entity
{
    public class TrainDetails                   //Entity class which has traindetails attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainId { get; set; }

        [Required]
        [Range(10000, 99999)]
        [Index(IsUnique = true)]
        public int TrainNo { get; set; }

        [Required]
        [MaxLength(25)]
        public string TrainName { get; set; }

        [Required]
        [MaxLength(30)]
        public string SourceStation { get; set; }

        [Required]
        [MaxLength(30)]
        public string DestinationStation { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [Required]
        [Range(100, 10000)]
        public int TrainKM { get; set; }

        //[Required]
        //public int TotalSeats { get; set; }

        [Required]
        public int PerKMCost { get; set; }

        public IList<TrainClassDetails> TrainClassDetails { get; set; } // One to many relationship with train class

        TrainDetails()
        {

        }
    }

}
