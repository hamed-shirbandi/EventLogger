using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using EventLogger.Service.EventLogs.Dto;
using System.Web.Mvc;

namespace EventLogger.Mvc
{
    public class ErrorLogFilter : HandleErrorAttribute
    {

        public ErrorLogFilter()
        {
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

            EventLogService.Create(log);
        }




    }
}
