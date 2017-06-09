using EventLogger.Service.ErrorLogs.Dto;
using System.Collections.Generic;
namespace EventLogger.Service.ErrorLogs
{
    public interface IErrorService
    {
        ErrorLogInput Create(ErrorLogInput input);
        ErrorLogInput Get(int id);
        IEnumerable<ErrorLogInput> Search();
        int Count();
    }
}
