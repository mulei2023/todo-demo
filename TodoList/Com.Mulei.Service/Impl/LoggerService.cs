using Com.Mulei.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Mulei.Infrastructure.Encryption;
using Com.Mulei.Service.Interface;

namespace Com.Mulei.Service.Impl
{
    public class LoggerService : ILoggerService
    {
        public void LogError(string error)
        {
            throw new NotImplementedException();
        }

        public void LogError(Exception errorEx)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string info)
        {
            throw new NotImplementedException();
        }
    }
}
