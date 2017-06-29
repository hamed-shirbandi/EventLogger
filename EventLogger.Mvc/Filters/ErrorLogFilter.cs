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
           
           
            var log = new EventLogInput
            {
                EventLogType = EventLogType.Event,
                Action = HttpRequestHelper.GetActionName(filterContext.RouteData),
                Controller = HttpRequestHelper.GetControllerName(filterContext.RouteData),
                RouteValues = HttpRequestHelper.GetRuteValues(filterContext.RouteData),
                UserName = HttpRequestHelper.GetCurrentUserName(filterContext.HttpContext),
                QueryString = HttpRequestHelper.GetQueryString(filterContext.HttpContext),
                Url = HttpRequestHelper.GetUrl(filterContext.HttpContext),
                UserAgent = HttpRequestHelper.GetUserAgent(filterContext.HttpContext),
                Ip = HttpRequestHelper.GetIpAddress(filterContext.HttpContext),
                PathInfo = HttpRequestHelper.GetPathInfo(filterContext.HttpContext),
                StatusCode =  ExceptionHelper.GetErrorStatusCode(filterContext.Exception),
                HelpLink = ExceptionHelper.GetHelpLink(filterContext.Exception),
                HResult = ExceptionHelper.GetHResult(filterContext.Exception),
                Message = ExceptionHelper.GetInnerException(filterContext.Exception),
                InnerMessage =ExceptionHelper.GetInnerException(filterContext.Exception),
                Source = ExceptionHelper.GetInnerException(filterContext.Exception),
                StackTrace = ExceptionHelper.GetInnerException(filterContext.Exception),
            };

            _eventService.Create(log);
        }

        


    }
}
