using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace Day4_CalculatorApp
{
    public class CalculatorAppTests
    {
        private Calculator _calc;
        [SetUp]
        public void Setup()
        {
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Information()
             .WriteTo.Console()
             .WriteTo.File("logs/test_log.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

            ILoggerFactory loggerFactory = new SerilogLoggerFactory(Log.Logger);
            ILogger<Calculator> logger = loggerFactory.CreateLogger<Calculator>();

            _calc = new Calculator(logger);
        }

        [Test]
        public void Add_ValidInputs_ReturnsSum()
        {
            var result = _calc.Add(5, 3);
            Assert.That(result, Is.EqualTo(8));
        }
    }
}
