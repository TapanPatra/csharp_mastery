using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06_SeleniumAutomation
{
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            var test = ReportManager.CreateTest("LoginWithValidCredentials");

            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            test.Info("Navigated to login page");

            var loginPage = new LoginPage(driver);
            loginPage.Login("student", "Password123");
            test.Info("Logged in with valid credentials");

            Assert.That(driver.FindElement(By.TagName("h1")).Text, Is.EqualTo("Logged In Successfully"));
            test.Pass("Login successful");
        }

        [Test, Retry(2)]
        public void Login_With_Valid_Credentials_Should_Pass()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            var loginPage = new LoginPage(driver);
            loginPage.Login("tomsmith", "SuperSecretPassword!");

            Assert.That(loginPage.GetLoginStatus(), Does.Contain("You logged into a secure area!"));
        }
    }
}
