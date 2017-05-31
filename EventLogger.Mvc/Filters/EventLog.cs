using EventLogger.Application.Events;
using EventLogger.Application.Events.Dto;
using EventLogger.Mvc.IocConfig;
using System;
using System.Web.Mvc;

namespace EventLogger.Mvc.Filters
{
    public class EventLog : ActionFilterAttribute
    {
        private readonly IEventService _eventService;

        public EventLog()
        {
            _eventService = EventLoggerSmObjectFactory.Container.GetInstance<IEventService>();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogEvent(filterContext);

            base.OnActionExecuting(filterContext);
        }



        private void LogEvent(ActionExecutingContext filterContext)
        {
            string routeValues = GetRuteValues(filterContext);

            var @event = new EventInput
            {
                Action = (string)filterContext.RouteData.Values["action"],
                Controller = (string)filterContext.RouteData.Values["controller"],
                RouteValues=routeValues,
                UserName = filterContext.HttpContext.User.Identity.Name,
            };


            _eventService.Create(@event);
        }


        private string GetRuteValues(ActionExecutingContext filterContext)
        {
            var keyValues = string.Empty;
            var keys = filterContext.RouteData.Values.Keys;
            var values = filterContext.RouteData.Values;

            foreach (var key in keys)
            {
                keyValues += key+" = "+(string)values[key]+ " , " ;
            }

            return keyValues;
        }
    }
}
