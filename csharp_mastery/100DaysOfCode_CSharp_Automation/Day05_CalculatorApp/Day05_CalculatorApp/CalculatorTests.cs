using Moq;

namespace Day05_CalculatorApp
{
    public class CalculatorTests
    {
        private Mock<ICalculatorLogger> _mockLogger;
        private Calculator _calculator;


        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ICalculatorLogger>();
            _calculator = new Calculator(_mockLogger.Object);
        }

        [Test]
        public async Task AddAsync_LogsInfo()
        {
            var result = await _calculator.AddAsync(2, 3);
            Assert.That(result, Is.EqualTo(5));
            _mockLogger.Verify( x => x.LogInfo("Add (2, 3) = 5"), Times.Once);
        }

        [Test]
        public void DivideAsync_ByZero_LogsError()
        {
            var ex = Assert.ThrowsAsync<DivideByZeroException>(() => _calculator.DivideAsync(10, 0));
            _mockLogger.Verify(x => x.LogError("Divide (10, 0) failed.", It.IsAny<Exception>()));
        }

    }
}
