using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02_CalculatorApp
{
    public class Calculator
    {
        public static double Add(int a, int b)
        {
            return a + b;
        }

        public static double Subtract(int a, int b)
        {
            return a - b;
        }

        public static double Multiply(int a, int b)
        {
            return a * b;
        }

        public static double Divide(int a, int b)
        {
            if(b == 0) 
                throw new DivideByZeroException("cannot divide by zero");

            return a / b;
        }

    }
}
