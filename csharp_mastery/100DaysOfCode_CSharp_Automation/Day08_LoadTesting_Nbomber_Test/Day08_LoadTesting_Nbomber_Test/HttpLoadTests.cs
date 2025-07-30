using NBomber.CSharp;
using NBomber.Http.CSharp;

namespace Day08_LoadTesting_Nbomber_Test
{
    public class HttpLoadTests
    {

        [Test]
        public void SimpleHttpLoadTest()
        {
            var httpClinet = new HttpClient();
            var scenario = Scenario.Create("http_scenario", async context =>
            {
                var request = Http.CreateRequest("GET", "https://nbomber.com")
                .WithHeader("Accept", "text/html")
                .WithBody(new StringContent("{ Some JSON }"));

                var response = await Http.Send(httpClinet, request);


                return response;

            })
                .WithLoadSimulations(
                Simulation.Inject(rate:100,
                interval:TimeSpan.FromSeconds(1),
                during:TimeSpan.FromMinutes(3))
                );


            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();

            
        }
    }
}
