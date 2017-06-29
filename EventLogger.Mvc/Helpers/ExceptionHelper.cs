using System;
using System.Web;

namespace EventLogger.Mvc
{
    public class ExceptionHelper
    {
  
        public static string GetInnerException(Exception ex)
        {
            var msg = "";
            if (ex.InnerException!=null)
            {
                msg= ex.InnerException.Message;
            }
            return msg;
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
