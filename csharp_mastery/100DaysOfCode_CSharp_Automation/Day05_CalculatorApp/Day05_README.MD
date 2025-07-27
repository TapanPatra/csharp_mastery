#  Day 05 – Moq in C#
**Goal: Mocking with Moq & Verifying Logs — an essential skill for Automation Engineers when unit testing services with dependencies. Custom Logging Abstraction with Interface — a valuable design pattern for clean, testable automation codebases.**


---

✅ **Tasks:**  
- [x] Create an ICalculatorLogger interface
- [x] Refactor Calculator to depend on it instead of ILogger<Calculator>
- [x] Implement a concrete logger using ILogger (e.g., from Serilog or Console)
- [x] Refactor Calculator methods to be async
- [x] Update tests using async and await
- [x] Introduce the Moq library to mock interfaces: Creating a Mock
- [x] Inject ILogger<Calculator> using a mock
- [x] Verify that logging calls are made with expected messages
- [x] Continue using NUnit

---

## Moq
What is Moq?  
Moq is a popular mocking framework for .NET. It helps you create fake versions of interfaces or classes so you can:
- Simulate behavior
- Control responses
- Verify method calls
- Capture arguments

### 📦 Setup,💡 NuGet Packages
Install the following packages:
```bash
dotnet add package Moq
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

### Basic Concepts of Moq
```csharp
var mockLogger = new Mock<ICalculatorLogger>();
```
### Injecting the Mock
```csharp
var calculator = new Calculator(mockLogger.Object);
```
### Verifying Behavior
```csharp
mockLogger.Verify(x => x.LogInfo("Add(2, 3) = 5"), Times.Once);
```
### Setting up Return Values
```csharp
var mockService = new Mock<IExchangeService>();
mockService.Setup(x => x.GetRate("USD", "INR")).Returns(83.5m);
```
### Handling Exceptions
```csharp
mockService.Setup(x => x.GetRate("USD", "INR"))
           .Throws(new Exception("Service unavailable"));
```
### Real Test Example with Moq
```csharp
public interface ILoggerService
{
    void Log(string message);
}

public class MathService
{
    private readonly ILoggerService _logger;

    public MathService(ILoggerService logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        int sum = a + b;
        _logger.Log($"Add: {a} + {b} = {sum}");
        return sum;
    }
}

[Test]
public void Add_LogsCorrectMessage()
{
    var mockLogger = new Mock<ILoggerService>();
    var service = new MathService(mockLogger.Object);

    int result = service.Add(2, 3);

    Assert.AreEqual(5, result);
    mockLogger.Verify(x => x.Log("Add: 2 + 3 = 5"), Times.Once);
}
```
