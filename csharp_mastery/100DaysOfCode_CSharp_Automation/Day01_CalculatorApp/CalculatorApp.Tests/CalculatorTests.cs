using NUnit.Framework;
using CalculatorApp;

namespace CalculatorApp.Tests
{

    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calc;

        [SetUp]
        public void Setup() => _calc = new Calculator();

        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            Assert.That(Calculator.Add(5, 3), Is.EqualTo(8));
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            Assert.That(Calculator.Subtract(5, 3), Is.EqualTo(2));
        }
    }
}
