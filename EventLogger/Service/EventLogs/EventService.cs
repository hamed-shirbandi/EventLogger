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

        private readonly IDbSet<EventLog> _logs;
        private readonly EventLoggerContext _con;

        #endregion

        #region Ctor

        public EventService()
        {
            _con = new EventLoggerContext();
            _logs = _con.Set<EventLog>();
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

            _logs.Add(log);
            _con.SaveChanges();
        }




        /// <summary>
        /// 
        /// </summary>
        public EventLogOutput Get(int id)
        {
            var log = _logs.FirstOrDefault(e => e.Id == id);

            if (log == null)
            {
                throw new Exception("Event not found in database");
            }

            return new EventLogOutput
            {
                Id = log.Id,
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
        public IEnumerable<EventLogOutput> Search(EventLogType eventLogType, int page, int recordsPerPage, string term, SortOrder sortOrder, out int pageSize, out int TotalItemCount)
        {
            var queryable = _logs.Where(log=> log.EventLogType== eventLogType).AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(log => log.Message.Contains(term) || log.InnerMessage.Contains(term)|| log.Source.Contains(term) || log.UserName.Contains(term) || log.Url.Contains(term) || log.RouteValues.Contains(term) || log.QueryString.Contains(term));
            }

            queryable = sortOrder == SortOrder.Asc ? queryable.OrderBy(log => log.CreateDateTime) : queryable.OrderByDescending(log => log.CreateDateTime);

            TotalItemCount = queryable.Count();
            pageSize = (int)Math.Ceiling((double)TotalItemCount / recordsPerPage);

            page = page > pageSize || page < 1 ? 1 : page;


            var skiped = (page - 1) * recordsPerPage;
            queryable = queryable.Skip(skiped).Take(recordsPerPage);



            return queryable.Select(log => new EventLogOutput
            {
                Id = log.Id,
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
            return _logs.Count(e => e.EventLogType == eventLogType);
        }






        #endregion

        #region Private Methods


        #endregion

    }
}
