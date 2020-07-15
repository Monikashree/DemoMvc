using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    
    public class TrainDetailsViewModel          //Entity attributes with regex and Display name
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainId { get; set; }

        [Required(ErrorMessage = "Train Number is required")]       
        [Range(10000, 99999 , ErrorMessage = "Please enter valid train number")]
        [Display(Name = "Train No")]
        public int TrainNo { get; set; }

        [Required(ErrorMessage = "Train Name is required")]
        //[RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]       
        [Display(Name = "Train Name")]
        public string TrainName { get; set; }

        [Required(ErrorMessage = "Source station is required")]
        [RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]        
        [Display(Name = "Source Station")]
        public string SourceStation { get; set; }

        [Required(ErrorMessage = "Destination station is required")]
        [RegularExpression("^[A-Z][a-z ]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]       
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

        public IList<TrainClassDetailsViewModel> TrainClassDetails { get; set; }    //One to may relationship

        TrainDetailsViewModel()
        {

        }
    }
}