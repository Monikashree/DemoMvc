using OnlineTrainTicketBookingMVC.App_Start;
using OnlineTrainTicketBookingMVC.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineTrainTicketBookingMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MappingConfig.RegisterMaps();
            FilterConfig.RegisterActionFilters(GlobalFilters.Filters);
        }
    }
}
