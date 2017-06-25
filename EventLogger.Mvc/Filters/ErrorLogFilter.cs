using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using EventLogger.Service.EventLogs.Dto;
using System.Web.Mvc;

namespace EventLogger.Mvc
{
   public class ErrorLogFilter :HandleErrorAttribute
    {
        private readonly IEventService _eventService;

        public ErrorLogFilter()
        {
            _eventService = new EventService();
        }


        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {

              LogError(filterContext);

                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                };

                filterContext.ExceptionHandled = true;
            }
        }



        private void LogError(ExceptionContext filterContext)
        {
           
            string routeValues = ExceptionHelper.GetRuteValues(filterContext);

            var log = new EventLogInput
            {
                EventLogType = EventLogType.Error,
                Action = filterContext.RouteData.Values["action"].ToString(),
                Controller = filterContext.RouteData.Values["controller"].ToString(),
                RouteValues = routeValues,
                UserName = filterContext.HttpContext.User.Identity.Name,
                QueryString = filterContext.HttpContext.Request.Url.Query,
                Url = filterContext.HttpContext.Request.Path,
                UserAgent = filterContext.HttpContext.Request.UserAgent,
                Ip = filterContext.HttpContext.Request.UserHostAddress,
                PathInfo = filterContext.HttpContext.Request.PathInfo,

                HelpLink = filterContext.Exception.HelpLink,
                HResult = filterContext.Exception.HResult,
                Message = filterContext.Exception.Message,
                InnerMessage=ExceptionHelper.GetInnerException(filterContext.Exception),
                Source = filterContext.Exception.Source,
                StackTrace = filterContext.Exception.StackTrace,
            };

            _eventService.Create(log);
        }

        


    }
}
