using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Day03_CalculatorApp
{
    [TestFixture]
    public class CalculatorTests
    {

        private Calculator? _calc;

        [SetUp]
        public void SetUp()
        {
            var logger = NullLogger<Calculator>.Instance;
            _calc = new Calculator(logger);
        }
        [Test]
        public void Add_ValidInputs_ReturnsSum()
        {
            var result = _calc.Add(5, 3);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Subtract_ValidInputs_ReturnsDifference()
        {
            var result = _calc.Subtract(10, 4);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Multiply_ValidInputs_ReturnsProduct()
        {
            var result = _calc.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Divide_ValidInputs_ReturnsQuotient()
        {
            var result = _calc.Divide(20, 5);
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
        }
    }
}
