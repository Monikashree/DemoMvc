using System;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.App_Start
{
    public class CustomError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                string controller = (string)exceptionContext.RouteData.Values["controller"];
                string action = (string)exceptionContext.RouteData.Values["action"];
                Exception customException = new Exception("There may be some issues");
                var model = new HandleErrorInfo(customException, controller, action);
                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/_CustomErrorView.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = exceptionContext.Controller.TempData
                };
                exceptionContext.ExceptionHandled = true;
            }
        }

    }
}