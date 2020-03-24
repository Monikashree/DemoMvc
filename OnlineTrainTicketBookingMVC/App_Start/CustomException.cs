using System;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.App_Start
{
    public class CustomException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is Exception)
            {
                filterContext.Result = new RedirectResult("~/Filter/ErrorMessage.cshtml");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}