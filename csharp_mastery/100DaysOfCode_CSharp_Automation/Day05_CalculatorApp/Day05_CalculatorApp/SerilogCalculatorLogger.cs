using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Day05_CalculatorApp
{
    public class SerilogCalculatorLogger : ICalculatorLogger
    {
        private readonly ILogger _logger;

        public SerilogCalculatorLogger(ILogger logger)
        {
            _logger = logger;
        }
        public void LogError(string message, Exception ex = null)
        {
            _logger.LogError(ex, message);
        }

        public void LogInfo(string message)
        {
           _logger.LogInformation(message);
        }
    }
}
