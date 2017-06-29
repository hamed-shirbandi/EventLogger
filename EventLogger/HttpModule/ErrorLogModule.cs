using EventLogger.Enums;
using EventLogger.Service.EventLogs;
using EventLogger.Service.EventLogs.Dto;
using System;
using System.Web;

namespace EventLogger
{

    public class ErrorLogModule : IHttpModule
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
        /// The handler called when an unhandled exception bubbles up to the module.
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
        private void LogError(Exception exception, HttpContextBase httpContext)
        {

            var log = HttpRequestHelper.GetHttpRequestInfo(httpContext, null);
            log = ExceptionHelper.GetExceptionInfo(exception, log);
            log.EventLogType = EventLogType.Error;

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