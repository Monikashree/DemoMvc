using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class SearchTrainViewModel
    {
        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime JourneyDate { get; set; }

        public SearchTrainViewModel()
        { }
    }
}