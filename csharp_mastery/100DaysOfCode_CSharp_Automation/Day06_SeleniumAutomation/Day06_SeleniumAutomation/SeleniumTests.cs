using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Day06_SeleniumAutomation
{
    public class SeleniumTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetChromeDriver();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void OpenAppTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.That(driver.Title, Does.Contain("Google"));
        }
    }
}
