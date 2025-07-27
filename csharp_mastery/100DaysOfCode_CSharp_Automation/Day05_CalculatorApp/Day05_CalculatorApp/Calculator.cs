using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05_CalculatorApp
{
    public class Calculator
    {
        private ICalculatorLogger _logger;

        public Calculator(ICalculatorLogger logger) 
        { 
            _logger = logger;
        }


        public async Task<int> AddAsync(int a, int b)
        {
            await Task.Delay(10000);
            var result = a + b;
            _logger.LogInfo($"Add {a}, {b} = {result}");
            await Task.Delay(10000);
            return result;
        }

        public async Task<double> DivideAsync(int a, int b)
        {
            await Task.Delay(10000);
            if (b == 0)
            {
                var ex = new DivideByZeroException("Cannot divide by zero.");
                _logger.LogError($"Divide {a}, {b}) failed.", ex);
                throw ex;
            }
            var result = a / b;
            _logger.LogInfo($"Divide {a}, {b} = {result}");
            await Task.Delay(10000);
            return result;
        }

    }
}
