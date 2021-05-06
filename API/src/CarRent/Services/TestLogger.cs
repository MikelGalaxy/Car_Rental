using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Services
{
    
    public class TestLogger : ILoggingService
    {
        private readonly ILogger _logger;

        public TestLogger(ILogger<TestLogger> logger)
        {
            _logger = logger;
        }

        public void LoggMessage(string message, params object[] parameters)
        {
            _logger.LogInformation(message, parameters);
        }
    }
}
