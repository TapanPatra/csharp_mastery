using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace Day06_SeleniumAutomation
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static void CreateReport()
        {
            Directory.CreateDirectory("Reports");
            var htmlReporter = new ExtentHtmlReporter("Reports/ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        public static ExtentTest CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
            return _test;
        }

        public static ExtentTest CurrentTest => _test;

        public static void FlushReport() => _extent.Flush();
    }
}
