using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._13_ModernCSharp
{
    [TestFixture]
    public class Tuples
    {
        public (int Sum, int Product) Calculate(int num1, int num2)
        {
            return (num1 + num2, num1 * num2);
        }

        [Test]
        public void TuppleTest()
        {
            int num1 = 5;
            int num2 = 10;
            var result = Calculate(num1, num2);
            Console.WriteLine(result.Sum);
            Console.WriteLine(result.Product);
        }

    }
}
