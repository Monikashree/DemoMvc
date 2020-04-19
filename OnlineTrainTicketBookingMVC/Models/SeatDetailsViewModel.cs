using System.Collections.Generic;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class SeatDetailsViewModel
    {
        public IList<TrainDetailsViewModel> TrainDetails { get; set; }

        public IList<TrainClassViewModel> TrainClass { get; set; }

        public IList<TrainClassDetailsViewModel> TrainClassDetails { get; set; }

        public SeatDetailsViewModel()
        {

        }


    }
}