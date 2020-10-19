using OnlineTrainTicketBookingApp.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC
{
    public class TrainClassDetails                  //Entity class which has TrainClassDetails Attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainClassDetailsId { get; set; }


        public int TrainId { get; set; }
        public TrainDetails TrainDetails { get; set; }


        public int ClassId { get; set; }
        public TrainClass TrainClasses { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        [Range(100, 2000)]
        public int Cost { get; set; }
    }
}
