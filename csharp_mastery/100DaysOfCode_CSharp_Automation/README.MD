# 100 Days of Code C# Automation

## Day 1
Goal: Set up your C# development environment and write your first automation-oriented program.  
- [x] Setup project repository
- [x] Install Visual Studio or Visual Studio Code (if not already installed).
- [x] Create a new Console App project.
- [x] Write a Calculator class with basic methods: Add, Subtract.
- [x] Add a simple test using NUnit.

## Day 2 
Goal: Extend the Calculator with Multiply and Divide methods and write NUnit tests including division by zero handling.
- [x] Add Multiply and Divide methods
- [x] Handle divide-by-zero with exception
- [x] Update NUnit tests to cover new methods and edge cases

## Day 3 
Goal: Integrate structured logging into the Calculator using ILogger<Calculator>.
- Use Microsoft.Extensions.Logging.ILogger
- Log method name, input, and result
- Refactor tests to inject a logger (mock or real)

## Day 4 
Goal: Logging with Serilog — structured, file-based logging with dependency injection.
- Integrate Serilog for logging
- Log method calls to both console and file
- Keep your testability intact by injecting the logger
