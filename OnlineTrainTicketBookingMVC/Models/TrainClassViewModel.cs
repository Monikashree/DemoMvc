using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class TrainClassViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(25)]
        [RegularExpression("^[A-Z][a-z]*[0-9]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z) (0-9)")]
        public string ClassName { get; set; }

        public IList<TrainClassDetails> TrainClassDetails { get; set; }
    }
}