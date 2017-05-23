using EventLogger.Application.Errors.Dto;
using EventLogger.Core.Domain;
using EventLogger.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogger.Application.Errors
{
    public class ErrorService : IErrorService
    {
        #region properties

        private readonly IDbSet<Error> _errors;
        private readonly IUnitOfWork _uow;

        #endregion

        #region Ctor

        public ErrorService(IUnitOfWork uow)
        {
            _uow = uow;
            _errors = _uow.Set<Error>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public ErrorInput Create(ErrorInput input)
        {
            var error = new Error
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
            _uow.SaveChanges();

            input.Id = result.Id;
            return input;
        }






        /// <summary>
        /// 
        /// </summary>
        public ErrorInput Get(int id)
        {
            var error = _errors.FirstOrDefault(e=>e.Id==id);

            if (error==null)
            {
                throw new Exception("error not found in database");
            }

            return new ErrorInput
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
        public IEnumerable<ErrorInput> Search()
        {
            return _errors.Select(error => new ErrorInput
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
