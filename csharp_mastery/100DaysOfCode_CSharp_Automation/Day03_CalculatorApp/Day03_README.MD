# Day 03 – Log Using Microsoft.Extensions.Logging.ILogger
**Goal: Integrate structured logging into the Calculator using ILogger<Calculator>.**
**Tasks:**  
- [x] Use Microsoft.Extensions.Logging.ILogger
- [x] Log method name, input, and result
- [x] Refactor tests to inject a logger (mock or real)

## Summary of Learning & Cheat sheet 
### Install Required NuGet Package
```bash
dotnet add package Microsoft.Extensions.Logging
dotnet add package Microsoft.Extensions.Logging.Console
```
### Setup Logger in Console App (Basic)
```csharp
using Microsoft.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Debug); // Set global log level
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();

        logger.LogInformation("App started at {time}", DateTime.Now);
    }
}
```
### Log Levels

Method	|Description
------|------------|
LogTrace |Very detailed logs (dev only)
LogDebug | Debugging information
LogInformation	| Normal app flow logs
LogWarning	| Non-critical issue
LogError	| App errors
LogCritical	| System crash, data loss

```csharp
logger.LogTrace("This is a trace message");
logger.LogDebug("Debug info: {debug}", "details");
logger.LogInformation("User logged in at {time}", DateTime.Now);
logger.LogWarning("Disk space low");
logger.LogError("Exception occurred: {ex}", ex);
logger.LogCritical("App crashed!");
```
### Structured Logging
```csharp
logger.LogInformation("Order {orderId} processed for {customer}", 1234, "Alice");
```
### Dependency Injection
```csharp
public class HomeController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public void DoSomething()
    {
        _logger.LogInformation("Inside DoSomething()");
    }
}
```
### Logging Exceptions
```csharp
try
{
    throw new InvalidOperationException("Invalid operation!");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while processing request");
}
```
### Logging with EventId
```csharp
EventId orderEventId = new EventId(1001, "OrderProcessed");

logger.LogInformation(orderEventId, "Order processed: {OrderId}", 1234);
```
### Unit Testing with ILogger
```csharp
var logger = new LoggerFactory().CreateLogger<MyClass>();
// OR use NullLogger for tests
var logger = NullLogger<MyClass>.Instance;
```
### Custom Logger Provider
```csharp
public class CustomLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new CustomLogger();

    public void Dispose() { }
}
```
### Key Learning
Feature |	Example
------- | 
Info Log	| logger.LogInformation("Info")
Exception Log	| logger.LogError(ex, "Error occurred")
Structured Log	| logger.LogInformation("User {id}", 1)
Log Level Config	| .SetMinimumLevel(LogLevel.Warning)
Inject ILogger	| ILogger<MyClass> via DI