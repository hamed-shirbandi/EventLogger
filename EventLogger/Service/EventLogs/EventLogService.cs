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
    public  class EventLogService 
    {

        #region properties

  
        #endregion

        #region Ctor

        public EventLogService()
        {
           
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static double Create(EventLogInput input)
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
                PathInfo = input.PathInfo,
                QueryString = input.QueryString,
                Url = input.Url,
                UserAgent = input.UserAgent,
                Cookies=input.Cookies,
                Form=input.Form,
                MachineName=input.MachineName,
                PhysicalPath=input.PhysicalPath,
                PhysicalApplicationPath = input.PhysicalApplicationPath,
                ServerVariables = input.ServerVariables,
                UserHostName = input.UserHostName,
                HttpMethod = input.HttpMethod,
                HttpHost = input.HttpHost,
                Protocol = input.Protocol,
                Port = input.Port,
                UrlReferer = input.UrlReferer,
                
                //ex
                Source = input.Source,
                StackTrace = input.StackTrace,
                HelpLink = input.HelpLink,
                HResult = input.HResult,
                StatusCode = input.StatusCode,
                Message = input.Message,
                InnerMessage = input.InnerMessage,
                Details=input.Details,
                TypeName = input.TypeName,
                
            };
            using (var con =new EventLoggerContext())
            {
                log= con.EventLogs.Add(log);
                con.SaveChanges();
            }
            return log.Id;
        }




        /// <summary>
        /// 
        /// </summary>
        public static EventLogOutput Get(int id)
        {
            EventLog log;
            using (var con = new EventLoggerContext())
            {
                log = con.EventLogs.FirstOrDefault(e => e.Id == id);
            }

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
                PathInfo = log.PathInfo,
                QueryString = log.QueryString,
                Url = log.Url,
                UserAgent = log.UserAgent,
                Cookies = log.Cookies,
                Form = log.Form,
                MachineName = log.MachineName,
                PhysicalPath = log.PhysicalPath,
                PhysicalApplicationPath = log.PhysicalApplicationPath,
                ServerVariables = log.ServerVariables,
                UserHostName = log.UserHostName,
                HttpMethod = log.HttpMethod,
                HttpHost = log.HttpHost,
                Protocol = log.Protocol,
                Port = log.Port,
                UrlReferer = log.UrlReferer,

                //ex
                HelpLink = log.HelpLink,
                HResult = log.HResult,
                StatusCode = log.StatusCode,
                Message = log.Message,
                InnerMessage = log.InnerMessage,
                Source = log.Source,
                StackTrace = log.StackTrace,
                Details = log.Details,
                TypeName = log.TypeName,
                
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<EventLogOutput> Search(EventLogType eventLogType, int page, int recordsPerPage, string term, SortOrder sortOrder, out int pageSize, out int TotalItemCount)
        {
            using (var con = new EventLoggerContext())
            {
                var queryable = con.EventLogs.Where(log => log.EventLogType == eventLogType).AsQueryable();
                if (!string.IsNullOrEmpty(term))
                {
                    queryable = queryable.Where(log => log.Message.Contains(term) || log.InnerMessage.Contains(term) || log.Source.Contains(term) || log.UserName.Contains(term) || log.Url.Contains(term) || log.RouteValues.Contains(term) || log.QueryString.Contains(term));
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
                    PathInfo = log.PathInfo,
                    QueryString = log.QueryString,
                    Url = log.Url,
                    UserAgent = log.UserAgent,
                    Cookies = log.Cookies,
                    Form = log.Form,
                    MachineName = log.MachineName,
                    PhysicalPath = log.PhysicalPath,
                    PhysicalApplicationPath = log.PhysicalApplicationPath,
                    ServerVariables = log.ServerVariables,
                    UserHostName = log.UserHostName,
                    HttpMethod = log.HttpMethod,
                    HttpHost = log.HttpHost,
                    Protocol = log.Protocol,
                    Port = log.Port,
                    UrlReferer = log.UrlReferer,

                    //ex
                    HelpLink = log.HelpLink,
                    HResult = log.HResult,
                    StatusCode = log.StatusCode,
                    Message = log.Message,
                    InnerMessage = log.InnerMessage,
                    Source = log.Source,
                    StackTrace = log.StackTrace,
                    Details = log.Details,
                    TypeName = log.TypeName,

                }).ToList();
            }

            
        }






        /// <summary>
        /// 
        /// </summary>
        public static int Count(EventLogType eventLogType)
        {
            using (var con = new EventLoggerContext())
            {
                return con.EventLogs.Count(e => e.EventLogType == eventLogType);
            }
        }






        #endregion

        #region Private Methods


        #endregion

    }
}
