using System;

namespace EventLogger.Core.Domain
{
   public class Event
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteValues { get; set; }

    }
}
