using OnlineTrainTicketBookingMVC.App_Start;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

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

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var role = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), role);
                }
            }
        }
    }
}
