using EventLogger.Service.EventLogs.Dto;
using System.Collections.Generic;

namespace EventLogger.Service.EventLogs
{
    public interface IEventService
    {
        void Create(EventLogInput input);
        EventLogInput Get(int id);
        IEnumerable<EventLogInput> Search();
        int Count();
    }
}
