using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap < UserViewModel,User >();
            });
        }
    }
}