using EventLogger.Enums;
using System;

namespace EventLogger.Service.EventLogs.Dto
{
   public class EventLogOutput
    {
        public long Id { get; set; }
        public EventLogType EventLogType { get; set; }
        public DateTime CreateDateTime { get; set; }

        public string Ip { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteValues { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public string PathInfo { get; set; }
        public string QueryString { get; set; }
        public string UserAgent { get; set; }
        public string UserHostName { get; set; }
        public string PhysicalPath { get; set; }
        public string PhysicalApplicationPath { get; set; }

        public string MachineName { get; set; }
        public string Cookies { get; set; }
        public string ServerVariables { get; set; }
        public string Form { get; set; }
        public string HttpHost { get; set; }
        public string Port { get; set; }
        public string Protocol { get; set; }
        public string UrlReferer { get; set; }
        public string HttpMethod { get; set; }

        //ex
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public string HelpLink { get; set; }
        public int? HResult { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string TypeName { get; set; }
        public string Details { get; set; }


    }
}
