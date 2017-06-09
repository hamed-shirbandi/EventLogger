using EventLogger.Service.EventLogs.Dto;
using EventLogger.Domain;
using EventLogger.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EventLogger.Service.EventLogs
{
   public class EventService : IEventService
    {

        #region properties

        private readonly IDbSet<EventLog> _Events;
        private readonly EventLoggerContext _con;

        #endregion

        #region Ctor

        public EventService( )
        {
            _con = new EventLoggerContext();
            _Events = _con.Set<EventLog>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Create(EventLogInput input)
        {
            var Event = new EventLog
            {
                Action = input.Action,
                Controller = input.Controller,
                RouteValues = input.RouteValues,
                UserName = input.UserName,
                CreateDateTime = DateTime.Now,
                
            };

            _Events.Add(Event);
            _con.SaveChanges();
        }






        /// <summary>
        /// 
        /// </summary>
        public EventLogInput Get(int id)
        {
            var Event = _Events.FirstOrDefault(e => e.Id == id);

            if (Event == null)
            {
                throw new Exception("Event not found in database");
            }

            return new EventLogInput
            {
                Id = Event.Id,
                Action = Event.Action,
                Controller = Event.Controller,
                RouteValues = Event.RouteValues,
                UserName = Event.UserName,
                CreateDateTime = Event.CreateDateTime,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<EventLogInput> Search()
        {
            return _Events.Select(Event => new EventLogInput
            {
                Id = Event.Id,
                Action = Event.Action,
                Controller = Event.Controller,
                RouteValues = Event.RouteValues,
                UserName = Event.UserName,
                CreateDateTime = Event.CreateDateTime,


            }).ToList();
        }






        /// <summary>
        /// 
        /// </summary>
        public int Count()
        {
            return _Events.Count();
        }






        #endregion

        #region Private Methods


        #endregion

    }
}
