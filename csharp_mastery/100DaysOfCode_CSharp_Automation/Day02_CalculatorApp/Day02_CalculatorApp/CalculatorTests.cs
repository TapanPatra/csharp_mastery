using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Day02_CalculatorApp
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AddValidInputShouldReturnSum()
        {
            var result = Calculator.Add(5, 10);
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void SubtractValidInputsReturnDifference()
        {
            var result = Calculator.Subtract(10, 5);
            Assert.That (result, Is.EqualTo(5));
        }

        [Test]
        public void MultiplyValidInputsReturnDifference()
        {
            var result = Calculator.Multiply(10, 5);
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void DivideValidInputsReturnQuotient()
        {
            var result = Calculator.Divide(10, 5);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void DivideByZeroThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(10, 0));
        }
    }
}
