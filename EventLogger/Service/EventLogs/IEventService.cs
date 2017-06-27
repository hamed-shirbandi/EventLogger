using EventLogger.Enums;
using EventLogger.Service.EventLogs.Dto;
using System.Collections.Generic;

namespace EventLogger.Service.EventLogs
{
    public interface IEventService
    {
        void Create(EventLogInput input);
        EventLogOutput Get(int id);
        IEnumerable<EventLogOutput> Search(EventLogType eventLogType, int page, int recordsPerPage, string term, SortOrder sortOrder, out int pageSize, out int TotalItemCount);

        int Count(EventLogType eventLogType);
    }
}
