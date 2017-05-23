using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogger.Application.Events.Dto
{
   public class EventInput
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string RouteValues { get; set; }
    }
}
