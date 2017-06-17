
using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using EventLogger.Service.EventLogs.Dto;
using System;
using System.Web;

namespace EventLogger.Mvc
{

    /// <summary>
    /// HTTP module implementation that logs unhandled exceptions in an
    /// ASP.NET Web application to an error log.
    /// </summary>

    public class ErrorLogModule : IHttpModule// move to EventLogger
    {

        private readonly IEventService _eventService;



        /// <summary>
        /// 
        /// </summary>
        public ErrorLogModule()
        {
            _eventService = new EventService();
        }





        /// <summary>
        /// 
        /// </summary>
        public void Init(HttpApplication application)
        {
            if (application == null)
                throw new ArgumentNullException("application");

            application.Error += OnError;

        }



        /// <summary>
        /// The handler called when an unhandled exception bubbles up to 
        /// the module.
        /// </summary>
        protected virtual void OnError(object sender, EventArgs args)
        {
            var application = (HttpApplication)sender;

            var error = application.Server.GetLastError();

            LogError(error, new HttpContextWrapper(application.Context));
        }




        /// <summary>
        /// 
        /// </summary>
        private void LogError(Exception ex, HttpContextBase context)
        {
         
            var log = new EventLogInput
            {
                EventLogType = EventLogType.Error,
                QueryString = context.Request.Url.Query,
                Url = context.Request.Path,
                UserAgent = context.Request.UserAgent,
                Ip = context.Request.UserHostAddress,
                PathInfo = context.Request.PathInfo,

                HelpLink = ex.HelpLink,
                HResult = ex.HResult,
                Message = ex.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace,
                
            };

            _eventService.Create(log);

        }





        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {

        }

    }


}