using EventLogger.Service.EventLogs.Dto;
using System;
using System.Web;

namespace EventLogger
{
    public class ExceptionHelper
    {
        public static EventLogInput GetExceptionInfo(Exception exception, EventLogInput eventLog)
        {
            eventLog.StatusCode = GetErrorStatusCode(exception);
            eventLog.HelpLink = GetHelpLink(exception);
            eventLog.HResult = GetHResult(exception);
            eventLog.Message = GetMessage(exception);
            eventLog.InnerMessage = GetInnerException(exception);
            eventLog.Source = GetSource(exception);
            eventLog.StackTrace = GetStackTrace(exception);
            eventLog.TypeName = GetTypeName(exception);
            eventLog.Details = GetDetails(exception);

            return eventLog;
        }

        public static string GetInnerException(Exception ex)
        {
            var msg = "";
            if (ex.InnerException != null)
            {
                msg = ex.InnerException.Message;
            }
            return msg;
        }

        public static string GetTypeName(Exception ex)
        {
            return ex.GetType().FullName;
        }
        public static string GetDetails(Exception ex)
        {
            return ex.ToString();
        }
        public static string GetHelpLink(Exception ex)
        {
            return ex.HelpLink;
        }
        public static int? GetHResult(Exception ex)
        {
            return ex.HResult;
        }
        public static string GetMessage(Exception ex)
        {
            return ex.Message;
        }
        public static string GetSource(Exception ex)
        {
            return ex.Source;
        }
        public static string GetStackTrace(Exception ex)
        {
            return ex.StackTrace;
        }
        public static int GetErrorStatusCode(Exception ex)
        {
            var httpEx = (HttpException)ex;
            return httpEx.GetHttpCode();
        }
    }
}
