using OnlineTrainTicketBookingMVC;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingApp.Entity
{
    public class TrainClass             //Train Class attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(25)]
        public string ClassName { get; set; }

        public IList<TrainClassDetails> TrainClassDetails { get; set; } // Showing many train classses to one train
    }
}
