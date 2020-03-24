using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingApp.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class TrainClassDetailsViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       //Intermediate view model to maintain the class and cost
        public int TrainClassDetailsId { get; set; }

        
        public int TrainId { get; set; }
        public TrainDetails TrainDetails { get; set; }


        public int ClassId { get; set; }
        public TrainClass TrainClass { get; set; }

        [Required(ErrorMessage = "Seats are required")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Please enter valid seats")]
        
        public int Seats { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Please enter valid Cost")]
        [Range(100, 2000, ErrorMessage = "Please enter valid Cost")]
        public int Cost { get; set; }
    }
}