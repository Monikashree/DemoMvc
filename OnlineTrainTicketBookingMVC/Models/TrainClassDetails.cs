using OnlineTrainTicketBookingApp.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class TrainClassDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainClassDetailsId { get; set; }

        
        public int TrainNo { get; set; }
        public TrainDetails TrainDetails { get; set; }


        public int ClassId { get; set; }
        public TrainClass TrainClass { get; set; }

        public int Seats { get; set; }

        public int Cost { get; set; }
    }
}