using OnlineTrainTicketBookingApp.Entity;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap < UserViewModel,User >();
                config.CreateMap<TrainDetailsViewModel, TrainDetails>();
            });
        }
    }
}