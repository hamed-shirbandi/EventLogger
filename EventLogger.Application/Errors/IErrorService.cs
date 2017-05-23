using EventLogger.Application.Errors.Dto;
using System;
using System.Collections.Generic;
namespace EventLogger.Application.Errors
{
    public interface IErrorService
    {
        ErrorInput Create(ErrorInput input);
        ErrorInput Get(int id);
        IEnumerable<ErrorInput> Search();
        int Count();
    }
}
