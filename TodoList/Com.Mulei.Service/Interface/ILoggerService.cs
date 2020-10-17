using System;

namespace Com.Mulei.Service.Interface
{
    public interface ILoggerService
    {
        void LogError(string error);
        void LogError(Exception errorEx);
        void LogInfo(string info);
        
    }
}