using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using EventLogger.Service.EventLogs.Dto;
using System.Web.Mvc;

namespace EventLogger.Mvc
{
    public class EventLogFilter : ActionFilterAttribute
    {
        private readonly IEventService _eventService;

        public EventLogFilter()
        {
            _eventService = new EventService();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogEvent(filterContext);

            base.OnActionExecuting(filterContext);
        }



        private void LogEvent(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var routeData = filterContext.RouteData;

            var log = HttpRequestHelper.GetHttpRequestInfo(httpContext, routeData);
            log.EventLogType = EventLogType.Event;
            
            _eventService.Create(log);
        }

        
    }
}
