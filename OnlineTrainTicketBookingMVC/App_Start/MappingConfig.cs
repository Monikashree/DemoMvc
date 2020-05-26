using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;

namespace OnlineTrainTicketBookingMVC.App_Start
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<UserViewModel, User>();
                config.CreateMap<TrainDetailsViewModel, TrainDetails>();
                config.CreateMap<TrainClassDetails, TrainClassDetailsViewModel>();
                config.CreateMap<TrainClassDetailsViewModel, TrainClassDetails>();
                config.CreateMap<TrainDetails, TrainDetailsViewModel>();
                config.CreateMap<User, UserViewModel>();
                config.CreateMap<TicketBooking, TicketBookingViewModel>();
                config.CreateMap<TicketBookingViewModel, TicketBooking>();
                config.CreateMap<PassengerDetailsViewModel, PassengerDetails>();
                config.CreateMap<PassengerDetails, PassengerDetailsViewModel>();

            });

        }
    }
}