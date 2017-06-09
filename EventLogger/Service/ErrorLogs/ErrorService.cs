using EventLogger.Context;
using EventLogger.Domain;
using EventLogger.Service.ErrorLogs.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EventLogger.Service.ErrorLogs
{
    public class ErrorService : IErrorService
    {
        #region properties

        private readonly IDbSet<ErrorLog> _errors;
        private readonly EventLoggerContext _con;

        #endregion

        #region Ctor

        public ErrorService()
        {
            _con = new EventLoggerContext();
            _errors = _con.Set<ErrorLog>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public long Create(ErrorLogInput input)
        {
            var error = new ErrorLog
            {
                Action = input.Action,
                Controller = input.Controller,
                RouteValues = input.RouteValues,
                HelpLink = input.HelpLink,
                HResult = input.HResult,
                Message = input.Message,
                Source = input.Source,
                StackTrace = input.StackTrace,
                UserName = input.UserName,
                CreateDateTime = DateTime.Now,
            };


           var result= _errors.Add(error);
            _con.SaveChanges();

            return result.Id;
        }






        /// <summary>
        /// 
        /// </summary>
        public ErrorLogInput Get(int id)
        {
            var error = _errors.FirstOrDefault(e=>e.Id==id);

            if (error==null)
            {
                throw new Exception("error not found in database");
            }

            return new ErrorLogInput
            {
                Id=error.Id,
                Action = error.Action,
                RouteValues = error.RouteValues,
                Controller = error.Controller,
                HelpLink = error.HelpLink,
                HResult = error.HResult,
                Message = error.Message,
                Source = error.Source,
                StackTrace = error.StackTrace,
                UserName = error.UserName,
                CreateDateTime = error.CreateDateTime,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ErrorLogInput> Search()
        {
            return _errors.Select(error => new ErrorLogInput
            {
                Id = error.Id,
                Action = error.Action,
                Controller = error.Controller,
                RouteValues = error.RouteValues,
                HelpLink = error.HelpLink,
                HResult = error.HResult,
                Message = error.Message,
                Source = error.Source,
                StackTrace = error.StackTrace,
                UserName = error.UserName,
                CreateDateTime = error.CreateDateTime,
            }).ToList();
        }






        /// <summary>
        /// 
        /// </summary>
        public int Count()
        {
            return _errors.Count();
        }




        #endregion

        #region Private Methods


        #endregion

    }
}
