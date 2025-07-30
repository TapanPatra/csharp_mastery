using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

        [Test]
        public void SelectDate()
        {
            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/bootstrap-date-picker-demo.html");
            driver.FindElement(By.XPath("//input[@placeholder='dd/mm/yyyy']")).Click();
            driver.FindElement(By.CssSelector(".day:not(.old):not(.new)")).Click(); // Selects today's date
        }

        [Test]
        public void UploadFile()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
            var fileInput = driver.FindElement(By.Id("file-upload"));
            fileInput.SendKeys(Path.GetFullPath("Resources/testfile.txt"));
            driver.FindElement(By.Id("file-submit")).Click();
        }

        [Test]
        public void ScrollToBottom()
        {
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        [Test]
        public void TakeScreenshot()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("google.png");
        }

        [Test]
        public void JsClick()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
            var button = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", button);
        }

        [Test]
        public void FluentWaitExample()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
            driver.FindElement(By.TagName("button")).Click();

            DefaultWait<IWebDriver> fluentWait = new(driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(drv => drv.FindElement(By.Id("finish")).Displayed);
            Assert.That(driver.FindElement(By.Id("finish")).Text.Contains("Hello"), Is.True);
        }


    }
}
