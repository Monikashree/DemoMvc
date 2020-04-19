using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.App_Start
{
    public class FilterConfig
    {
        //public static void RegisterActionFilters(GlobalFilterCollection globalFilterCollection)
        //{
        //    globalFilterCollection.Add(new HandleErrorAttribute());
        //}


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomException());
        }

        public class CustomException : FilterAttribute, IExceptionFilter
        {
            StringBuilder message = new StringBuilder();

            public void OnException(ExceptionContext filterContext)
            {
                message.Append(filterContext.RouteData.Values["controller"].ToString());
                message.Append(" ---> ");
                message.Append(filterContext.RouteData.Values["action"].ToString());
                message.Append(" ---> ");
                message.Append(filterContext.Exception.Message);
                message.Append(" ---> ");
                message.AppendLine(DateTime.Now.ToString());
                LogMessage(message.ToString());
                message.Clear();
                filterContext.ExceptionHandled = true;
                //if (HttpContext.Current.User.Identity.IsAuthenticated)
                //{
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "Error"
                    };
                //}
                //else
                //{
                //    filterContext.Result = new ViewResult()
                //    {
                //        ViewName = "ErrorSignUp"
                //    };
                //}


            }
            protected void LogMessage(string message)
            {
                System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("~/Logger/ExceptionLogger.txt"), message);
            }
        }
    }
}