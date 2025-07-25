using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Models;

namespace TestAutomation.Tests.APITesting
{
    [TestFixture]
    public class ApiTests
    {
        [OneTimeSetUp]
        public void InitReport()
        {

        }

        [OneTimeTearDown]
        public void FlushReport()
        {
           
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {
            var jsonData = File.ReadAllText("TestData/ApiTestData.json");
            var testCases = JsonConvert.DeserializeObject<List<TestCaseDataModel>>(jsonData);

            foreach (var testCase in testCases)
            {
                yield return new TestCaseData(testCase)
                    .SetName($"{testCase.CaseId}_{testCase.Method}");
            }
        }

        [Test, TestCaseSource(nameof(GetTestData))]
        public void Test_ApiMethods(TestCaseDataModel data)
        {
            Console.WriteLine(data.Method + ":" + data.Input + ":" + data.Expected );
        }


    }
}
