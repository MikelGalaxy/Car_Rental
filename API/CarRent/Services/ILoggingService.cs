using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Services
{
    public interface ILoggingService
    {
        void LoggMessage(string message, params object[] parameters);
    }
}
