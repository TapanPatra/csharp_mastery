# Day 01 – C# Class & NUnit Basics
**Goal:**  
Build a simple calculator class using C# that performs basic arithmetic operations like Add, Subtract, Multiply, and Divide. The focus is on clean code, object-oriented principles, and writing testable methods.

✅ **Tasks:**  
- Create a `Calculator` class  
- Implement the following methods:
  - `Add(int a, int b)`
  - `Subtract(int a, int b)`
  - `Multiply(int a, int b)`
  - `Divide(int a, int b)` with exception handling for divide-by-zero  
- Write NUnit test cases for all methods  
- Ensure the tests pass

---

## C# Class Syntax
```csharp
public class Calculator
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }
}
```
🧠 **Summary of Learning**

| Concept | Summary |
|--------|---------|
| C# Class | A blueprint for creating objects. Contains methods and properties. |
| Method Overloading | Can have multiple methods with same name but different parameters (not yet used here). |
| Exception Handling | Used `try-catch` to handle divide-by-zero in division logic. |
| NUnit Basics | Used `[TestFixture]` and `[Test]` attributes to write and run unit tests. |
| Assert | Used `Assert.AreEqual()` to verify the correctness of calculator methods. |

---

##  NUnit Testing 
```csharp
using NUnit.Framework;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup() => _calculator = new Calculator();

    [Test]
    public void Add_ShouldReturnCorrectSum()
    {
        Assert.AreEqual(5, _calculator.Add(2, 3));
    }

    [Test]
    public void Divide_ByZero_ShouldThrowException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
    }
}
```
| Attribute                           | Purpose                       |
|-------------------------------------|-------------------------------|
| [TestFixture]                       | Marks class as a test suite   |
| [SetUp]                             | Runs before each test         |
| [Test]                              | Marks a method as a test case |
| Assert.AreEqual(expected, actual)   | Checks if values match        |
| Assert.Throws<ExceptionType>(action)| Verifies expected exception   |

## Key Learnings
- C# class creation with public methods
- Exception handling using throw
- NUnit test structure with setup and assertions
- Importance of test method naming (Should pattern)
