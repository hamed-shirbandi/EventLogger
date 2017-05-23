using EventLogger.Application.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogger.Application.Events
{
    public interface IEventService
    {
        void Create(EventInput input);
        EventInput Get(int id);
        IEnumerable<EventInput> Search();
        int Count();
    }
}
