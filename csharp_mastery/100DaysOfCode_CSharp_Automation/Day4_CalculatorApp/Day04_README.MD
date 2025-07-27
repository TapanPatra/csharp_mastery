#  Day 04 – Logging with ILogger & Serilog in C#
**Goal: Logging with Serilog — structured, file-based logging with dependency injection.**

---

✅ **Tasks:**  
- Add Serilog NuGet package  
- Configure `Serilog` to log to console and file  
- Inject and use `ILogger<Calculator>` in the Calculator class  
- Log successful operations and divide-by-zero errors  
- Write NUnit test to verify logging (observational — not assertive)
- Integrate Serilog for logging
- Log method calls to both console and file
- Keep your testability intact by injecting the logger

---

## ILogger<T> Injection and Usage
```csharp
public class Calculator
{
    private readonly ILogger<Calculator> _logger;

    public Calculator(ILogger<Calculator> logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        int result = a + b;
        _logger.LogInformation("Add: {A} + {B} = {Result}", a, b, result);
        return result;
    }

    public int Divide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (DivideByZeroException ex)
        {
            _logger.LogError(ex, "Attempted divide by zero");
            throw;
        }
    }
}
```
## Serilog Configuration in Program Setup
```csharp
using Microsoft.Extensions.Logging;
using Serilog;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSerilog(new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger());
});

ILogger<Calculator> logger = loggerFactory.CreateLogger<Calculator>();
```
## Serilog Summary
| Feature               | Description |
|-----------------------|----------|
| ILogger<T>            | Dependency injection-based logging abstraction  |
| LogInformation        | Logs informational messages  |
| LogError              | Logs error messages with exceptions  |
| Serilog Sink          | Destination for logs (Console, File, etc.)  |
| Structured Logging    | Use {placeholders} with named parameters  |
| Rolling Logs          | Automatically rotate log files by day  |

## Logging in NUnit Test
```csharp 
[Test]
public void Add_LogsCorrectly()
{
    var logger = new LoggerFactory().CreateLogger<Calculator>();
    var calc = new Calculator(logger);

    int result = calc.Add(5, 7);

    Assert.AreEqual(12, result);
    // Log is not asserted here, only observed.
}
```