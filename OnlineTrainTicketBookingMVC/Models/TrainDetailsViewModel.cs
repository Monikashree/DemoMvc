using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class TrainDetailsViewModel
    {
        [Key]
        [Required(ErrorMessage = "Train Number is required")]
        public int TrainNo { get; set; }

        [Required(ErrorMessage = "Train Name is required")]
        public string TrainName { get; set; }

        [Required(ErrorMessage = "Source station is required")]
        public string SourceStation { get; set; }

        [Required(ErrorMessage = "Destination station is required")]
        public string DestinationStation { get; set; }

        [Required(ErrorMessage = "Departure time is required")]
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        public string ArrivalTime { get; set; }

        [Required(ErrorMessage = "TrainKM is required")]
        //[DataType(dataType:DateTime)]
        public int TrainKM { get; set; }

        //[Required(ErrorMessage = "Total seats is required")]
        //public int TotalSeats { get; set; }

        [Required(ErrorMessage = "PerKM cost is required")]
        public int PerKMCost { get; set; }

        //public int[] TrainClass { get; set; }

        public IList<TrainClassDetailsViewModel> TrainClassDetails { get; set; }
    }
}