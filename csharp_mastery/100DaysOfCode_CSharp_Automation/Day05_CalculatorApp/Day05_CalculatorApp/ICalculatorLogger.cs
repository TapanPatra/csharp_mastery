using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05_CalculatorApp
{
    public interface ICalculatorLogger
    {
        void LogInfo(string message);
        void LogError(string message, Exception ex = null);
    }
}
