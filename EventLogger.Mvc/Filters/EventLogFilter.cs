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
            string routeValues = HttpRequestHelper.GetRuteValues(filterContext);

            var log = new EventLogInput
            {
                EventLogType= EventLogType.Event,
                Action = filterContext.RouteData.Values["action"].ToString(),
                Controller = filterContext.RouteData.Values["controller"].ToString(),
                RouteValues=routeValues,
                UserName = filterContext.HttpContext.User.Identity.Name,
                QueryString=filterContext.HttpContext.Request.Url.Query,
                Url=filterContext.HttpContext.Request.Path,
                UserAgent=filterContext.HttpContext.Request.UserAgent,
                Ip=filterContext.HttpContext.Request.UserHostAddress,
                PathInfo= filterContext.HttpContext.Request.PathInfo,
                StatusCode = filterContext.HttpContext.Response.StatusCode,


            };

            _eventService.Create(log);
        }

        
    }
}
