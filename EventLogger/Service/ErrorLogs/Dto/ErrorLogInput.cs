using System;

namespace EventLogger.Service.ErrorLogs.Dto
{
   public class ErrorLogInput
    {
        public long Id { get; set; }
        public string HelpLink { get; set; }
        public int? HResult { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteValues { get; set; }

    }
}
