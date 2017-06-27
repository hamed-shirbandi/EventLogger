using EventLogger.Service.EventLogs.Dto;
using EventLogger.Domain;
using EventLogger.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EventLogger.Enums;

namespace EventLogger.Service.EventLogs
{
    public class EventService : IEventService
    {

        #region properties

        private readonly IDbSet<EventLog> _Events;
        private readonly EventLoggerContext _con;

        #endregion

        #region Ctor

        public EventService()
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
            var log = new EventLog
            {
                Action = input.Action,
                Controller = input.Controller,
                RouteValues = input.RouteValues,
                UserName = input.UserName,
                CreateDateTime = DateTime.Now,
                EventLogType = input.EventLogType,
                Ip = input.Ip,
                HelpLink = input.HelpLink,
                HResult = input.HResult,
                StatusCode = input.StatusCode,
                Message = input.Message,
                InnerMessage = input.InnerMessage,
                PathInfo = input.PathInfo,
                QueryString = input.QueryString,
                Source = input.Source,
                StackTrace = input.StackTrace,
                Url = input.Url,
                UserAgent = input.UserAgent,

            };

            _Events.Add(log);
            _con.SaveChanges();
        }

        


        /// <summary>
        /// 
        /// </summary>
        public EventLogOutput Get(int id)
        {
            var log = _Events.FirstOrDefault(e => e.Id == id);

            if (log == null)
            {
                throw new Exception("Event not found in database");
            }

            return new EventLogOutput
            {
                Id= log.Id,
                Action = log.Action,
                Controller = log.Controller,
                RouteValues = log.RouteValues,
                UserName = log.UserName,
                CreateDateTime = log.CreateDateTime,
                EventLogType = log.EventLogType,
                Ip = log.Ip,
                HelpLink = log.HelpLink,
                HResult = log.HResult,
                StatusCode = log.StatusCode,
                Message = log.Message,
                InnerMessage = log.InnerMessage,
                PathInfo = log.PathInfo,
                QueryString = log.QueryString,
                Source = log.Source,
                StackTrace = log.StackTrace,
                Url = log.Url,
                UserAgent = log.UserAgent,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<EventLogOutput> Search(EventLogType eventLogType)
        {
            return _Events.Where(e => e.EventLogType == eventLogType)
                .OrderByDescending(e => e.CreateDateTime)
                .Select(log => new EventLogOutput
                {
                    Id= log.Id,
                    Action = log.Action,
                    Controller = log.Controller,
                    RouteValues = log.RouteValues,
                    UserName = log.UserName,
                    CreateDateTime = log.CreateDateTime,
                    EventLogType = log.EventLogType,
                    Ip = log.Ip,
                    HelpLink = log.HelpLink,
                    HResult = log.HResult,
                    StatusCode = log.StatusCode,
                    Message = log.Message,
                    InnerMessage = log.InnerMessage,
                    PathInfo = log.PathInfo,
                    QueryString = log.QueryString,
                    Source = log.Source,
                    StackTrace = log.StackTrace,
                    Url = log.Url,
                    UserAgent = log.UserAgent,

                }).ToList();
        }






        /// <summary>
        /// 
        /// </summary>
        public int Count(EventLogType eventLogType)
        {
            return _Events.Count(e => e.EventLogType == eventLogType);
        }






        #endregion

        #region Private Methods


        #endregion

    }
}
