using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Day03_CalculatorApp
{
    public class Calculator(ILogger<Calculator> logger)
    {
        private readonly ILogger<Calculator> _logger = logger;

        public double Add(int a, int b)
        {
            var result = a + b;
            _logger.LogInformation("Add {a}, {b} ={result}", a, b, result);
            return result;
        }

        public double Subtract(int a, int b)
        {
            var result = a - b;
            _logger.LogInformation("Subtract {a}, {b} ={result}", a, b, result);
            return result;
        }

        public double Multiply(int a, int b)
        {
            var result = a * b;
            _logger.LogInformation("Subtract {a}, {b} ={result}", a, b, result);
            return result;
        }

        public double Divide(int a, int b)
        {
            if(a == 0 || b == 0)
            {
                _logger.LogError("Divide({a}, {b}) failed: Division by zero.", a, b);
                throw new DivideByZeroException("cannot divide by zero");
            }
            var result = a / b;
            _logger.LogInformation("Divide {a}, {b} ={result}", a, b, result);
            return result;
        }
    }
}
