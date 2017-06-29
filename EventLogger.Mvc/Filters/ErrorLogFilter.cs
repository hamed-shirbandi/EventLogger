using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using EventLogger.Service.EventLogs.Dto;
using System.Web.Mvc;

namespace EventLogger.Mvc
{
    public class ErrorLogFilter : HandleErrorAttribute
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
            var httpContext = filterContext.HttpContext;
            var routeData = filterContext.RouteData;
            var exception = filterContext.Exception;

            var log = HttpRequestHelper.GetHttpRequestInfo(httpContext, routeData);
             log = ExceptionHelper.GetExceptionInfo(exception, log);
            log.EventLogType = EventLogType.Error;

            _eventService.Create(log);
        }




    }
}
