using EventLogger.Application.Errors;
using EventLogger.Application.Errors.Dto;
using EventLogger.Mvc.IocConfig;
using System.Web.Mvc;
using System;

namespace EventLogger.Mvc.Filters
{
   public class ErrorLoger : FilterAttribute, IExceptionFilter
    {
        private readonly IErrorService _errorService;

        public ErrorLoger()
        {
            _errorService = EventLoggerSmObjectFactory.Container.GetInstance<IErrorService>();
        }


        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {

               var logId= LogError(filterContext);

                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<long>(logId)
                };
              
                filterContext.ExceptionHandled = true;
            }
        }



        private long LogError(ExceptionContext filterContext)
        {
            string routeValues = GetRuteValues(filterContext);

            var error = new ErrorInput
            {
                Action = (string)filterContext.RouteData.Values["action"],
                Controller = (string)filterContext.RouteData.Values["controller"],
                RouteValues = routeValues,
                HelpLink = filterContext.Exception.HelpLink,
                HResult = filterContext.Exception.HResult,
                Message = filterContext.Exception.Message,
                Source = filterContext.Exception.Source,
                StackTrace = filterContext.Exception.StackTrace,
                UserName = filterContext.HttpContext.User.Identity.Name,
            };


           var log= _errorService.Create(error);

            return log.Id;
        }





        private string GetRuteValues(ExceptionContext filterContext)
        {
            var keyValues = string.Empty;
            var keys = filterContext.RouteData.Values.Keys;
            var values = filterContext.RouteData.Values;

            foreach (var key in keys)
            {
                keyValues += key + " = " + (string)values[key] + " , ";
            }

            return keyValues;
        }

    }
}
