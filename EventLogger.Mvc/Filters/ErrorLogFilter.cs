using EventLogger.Service.ErrorLogs;
using EventLogger.Service.ErrorLogs.Dto;
using System.Web.Mvc;

namespace EventLogger.Mvc.Filters
{
   public class ErrorLogFilter : FilterAttribute, IExceptionFilter
    {
        private readonly IErrorService _errorService;

        public ErrorLogFilter()
        {
            _errorService =new ErrorService();
        }


        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {

               var logId= LogError(filterContext);

                filterContext.Result = new ViewResult
                {
                    ViewName = "ErrorLogView",
                    ViewData = new ViewDataDictionary<long>(logId)
                };
              
                filterContext.ExceptionHandled = true;
            }
        }



        private long LogError(ExceptionContext filterContext)
        {
            string routeValues = GetRuteValues(filterContext);

            var error = new ErrorLogInput
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


           var logId= _errorService.Create(error);

            return logId;
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
