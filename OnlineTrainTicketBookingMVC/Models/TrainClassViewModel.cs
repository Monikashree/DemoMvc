using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class TrainClassViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       // An view model with regex for Class details
        public int ClassId { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Class Name")]
        [RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]
        public string ClassName { get; set; }

        public IList<TrainClassDetailsViewModel> TrainClassDetails { get; set; }

         TrainClassViewModel()
        {

        }
    }
}