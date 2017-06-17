using EventLogger.Enums;
using EventLogger.Service.EventLogs.Dto;
using System.Collections.Generic;

namespace EventLogger.Service.EventLogs
{
    public interface IEventService
    {
        void Create(EventLogInput input);
        EventLogOutput Get(int id);
        IEnumerable<EventLogOutput> Search(EventLogType eventLogType);
        int Count(EventLogType eventLogType);
    }
}
