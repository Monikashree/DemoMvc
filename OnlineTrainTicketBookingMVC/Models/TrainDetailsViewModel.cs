using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTrainTicketBookingMVC.Models
{
    
    public class TrainDetailsViewModel
    {
        [Key]
        [Required(ErrorMessage = "Train Number is required")]
        [Display(Name = "Train No")]
        public int TrainNo { get; set; }

        [Required(ErrorMessage = "Train Name is required")]
        [Display(Name = "Train Name")]
        public string TrainName { get; set; }

        [Required(ErrorMessage = "Source station is required")]
        [Display(Name = "Source Station")]
        public string SourceStation { get; set; }

        [Required(ErrorMessage = "Destination station is required")]
        [Display(Name = "Destination Station")]
        public string DestinationStation { get; set; }

        [Required(ErrorMessage = "Departure time is required")]
        [Display(Name = "Departure Time")]
        public TimeSpan DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        [Display(Name = "Arrival Time")]
        public TimeSpan ArrivalTime { get; set; }

        [Required(ErrorMessage = "TrainKM is required")]
        [Display(Name = "Train KM")]
        //[DataType(dataType:DateTime)]
        [Range(100, 10000, ErrorMessage = "Please enter valid TrainKM")]
        public int TrainKM { get; set; }

        //[Required(ErrorMessage = "Total seats is required")]
        //public int TotalSeats { get; set; }

        [Required(ErrorMessage = "PerKM cost is required")]
        [Display(Name = "Per KM Cost")]
        public int PerKMCost { get; set; }

        //public int[] TrainClass { get; set; }

        public IList<TrainClassDetailsViewModel> TrainClassDetails { get; set; }
    }
}