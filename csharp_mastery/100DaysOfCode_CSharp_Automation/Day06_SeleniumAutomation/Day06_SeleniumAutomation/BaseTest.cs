using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Day06_SeleniumAutomation
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var htmlReporter = new ExtentHtmlReporter("Reports/ExtentReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string fileName = $"Reports/screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";
                screenshot.SaveAsFile(fileName);
                test.Fail("Test failed with screenshot").AddScreenCaptureFromPath(fileName);
            }

            driver.Quit();
            driver.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
        }
    }
}
