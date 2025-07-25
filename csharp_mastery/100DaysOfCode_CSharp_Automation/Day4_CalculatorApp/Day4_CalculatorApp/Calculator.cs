using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_CalculatorApp
{
    public class Calculator
    {
        private ILogger<Calculator> _logger;
        public Calculator(ILogger<Calculator> logger)
        {
            _logger = logger;
        }

        public double Add(int a, int b)
        {
            double result = a + b;
            _logger.LogInformation("Add {a}, {b} = {result}", a, b, result);
            return a + b;
        }
    }
}
