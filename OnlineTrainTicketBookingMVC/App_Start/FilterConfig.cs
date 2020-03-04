using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.App_Start
{
    public class FilterConfig
    {
        public static void RegisterActionFilters(GlobalFilterCollection globalFilterCollection)
        {
            globalFilterCollection.Add(new HandleErrorAttribute());
        }
    }
}