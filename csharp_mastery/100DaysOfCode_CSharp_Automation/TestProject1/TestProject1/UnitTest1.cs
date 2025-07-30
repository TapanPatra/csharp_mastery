using NBomber.Http;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using NBomber.Contracts;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var httpClient = Http.CreateDefaultClient();
            var scenario = Scenario.Create("http-scenario", async context =>
            {
                var request = Http.CreateRequest("GET", "https://restful-booker.herokuapp.com/booking/1")
                .WithHeader("Accept", "text/json");

                var response = await Http.Send(httpClient, request);
                return response.IsError ? Response.Fail() : Response.Ok();
            }).WithWarmUpDuration(TimeSpan.FromSeconds(1))
            .WithLoadSimulations(LoadSimulation.NewInject(2, TimeSpan.FromMilliseconds(10), TimeSpan.FromMinutes(1)));

           var result=  NBomberRunner.RegisterScenarios(scenario).Run();

            Assert.That(result.ScenarioStats.Get("http-scenario").AllFailCount<10, Is.True);
        }
    }
}
