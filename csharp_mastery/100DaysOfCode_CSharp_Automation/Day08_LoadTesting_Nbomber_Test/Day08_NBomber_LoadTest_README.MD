# NBomber

## NBomber Http
**Create Http Client**
```csharp
var httpClient = new HttpClient();
```
**create a scenario**
- Define scenario
- Each "user" (virtual user) in the scenario sends a GET request to https://nbomber.com with some headers.
- The response is returned to NBomber for metrics and assertions
```csharp
var scenario = Scenario.Create("http_scenario", async context =>
{
    var request =
        Http.CreateRequest("GET", "https://nbomber.com")
            .WithHeader("Accept", "text/html")
            .WithBody(new StringContent("{ some JSON }"));

    var response = await Http.Send(httpClient, request);

    return response;
})
```

**This simulates 100 new users per second for 3 minutes.**
```csharp
.WithLoadSimulations(
    Simulation.Inject(rate: 100,
                      interval: TimeSpan.FromSeconds(1),
                      during: TimeSpan.FromMinutes(3))
);

```
**Start the test by registering the scenario and running it.**
```csharp
NBomberRunner
    .RegisterScenarios(scenario)
    .Run();
```

## NBomber MQTT


## Metrics NBomber Tracks
After execution, NBomber provides:
- Request count
- Success rate
- Failures
- Latency percentiles
- Throughput
- Error reasons

