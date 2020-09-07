using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class SearchTrainViewModel       //Attributes of search train with key constraints
    {
        [Required(ErrorMessage = "Source station is required")]
        [RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Destination station is required")]
        [RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Column(TypeName = "date")]
        public DateTime JourneyDate { get; set; }

        public SearchTrainViewModel()
        { }
    }
}