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
           
            var log = new EventLogInput
            {
                EventLogType= EventLogType.Event,
                Action = HttpRequestHelper.GetActionName(filterContext.RouteData),
                Controller = HttpRequestHelper.GetControllerName(filterContext.RouteData),
                RouteValues= HttpRequestHelper.GetRuteValues(filterContext.RouteData),
                UserName = HttpRequestHelper.GetCurrentUserName(filterContext.HttpContext),
                QueryString = HttpRequestHelper.GetQueryString(filterContext.HttpContext),
                Url = HttpRequestHelper.GetUrl(filterContext.HttpContext),
                UserAgent = HttpRequestHelper.GetUserAgent(filterContext.HttpContext),
                Ip = HttpRequestHelper.GetIpAddress(filterContext.HttpContext),
                PathInfo = HttpRequestHelper.GetPathInfo(filterContext.HttpContext),


            };

            _eventService.Create(log);
        }

        
    }
}
