
using Calculator.DataLogger.ConsoleApp.Models;
using Calculator.DataLogger.ConsoleApp;
using Calculator.DataLogger.ConsoleApp.CalculatorCore;
using Calculator.DataLogger;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

Console.WriteLine("Start Application.");

Batteries.Init(); // ✅ REQUIRED for SQLite

using var db = new AppDbContext();
db.Database.EnsureCreated();

var calculator = new Calculator.DataLogger.ConsoleApp.CalculatorCore.Calculator();
var result = calculator.Add(10, 5);
Console.WriteLine($"Add(10, 5) = {result}");

db.CalculationLogs.Add(new CalculationLog
{
    Operation = "Add",
    Operand1 = 10,
    Operand2 = 5,
    Result = result,
    Timestamp = DateTime.UtcNow
});
db.SaveChanges();

Console.WriteLine("Calculation logged to SQLite database.");