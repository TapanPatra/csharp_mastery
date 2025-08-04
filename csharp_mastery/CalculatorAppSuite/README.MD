# CalculatorAppSuite

A comprehensive .NET-based calculator application suite demonstrating various application types and technology stacks using C#.

## 🚀 Overview

This solution showcases the implementation of a simple calculator (Add, Subtract, Multiply, Divide) across multiple .NET technologies:

- ✅ Console Application
- 🖥️ WPF (Windows Presentation Foundation)
- 🌐 ASP.NET Core Web UI (MVC or Razor Pages)
- 🔗 REST API using ASP.NET Core Web API
- 🧼 SOAP Web Service using WCF

Each project is independently functional, demonstrating how core business logic (Calculator operations) can be reused across different platforms and interfaces.

---

## 🧱 Solution Structure

```bash
CalculatorAppSuite/
│
├── CalculatorCoreLib/                  # Shared business logic (Add, Subtract, Multiply, Divide)
│
├── Calculator.DataLogger.ConsoleApp/   # Console interface for calculator
│
├── CalculatorUI/                       # WPF Desktop UI using MVVM
│
├── CalculatorWebUI/                    # ASP.NET Core MVC or Razor Pages frontend
│
├── CalculatorRestApi/                  # ASP.NET Core Web API (JSON)
│
├── CalculatorSoapApi/                  # WCF SOAP service (XML)
│
├── CalculatorMobileUI/                 # Universal App for Android, Ios, Windows
├── CalculatorTests/                    # NUnit tests for core logic and services
│
└── README.md                           # Project documentation
```
## Calculator Test
- **REST API Endpoint :** http://localhost:5000/api/calculator/add?a=10&b=5
- **Soap API WSDL :** http://localhost:5010/Calculator.svc?wsdl
- **WEB APP :** http://localhost:5204/Calculator
- **WPF UI :** \CalculatorAppSuite\CalculatorUI\bin\Debug\net8.0-windows\CalculatorUI.exe
- **MAU UI :** \CalculatorAppSuite\CalculatorMobileUI\bin\Debug\net9.0-windows10.0.19041.0\win10-x64\CalculatorMobileUI.exe
- **Core Lib :** \CalculatorAppSuite\CalculatorCoreLib\bin\Debug\net8.0\CalculatorCoreLib.dll
- **Database :** \CalculatorAppSuite\Calculator.DataLogger.ConsoleApp\bin\Debug\net8.0\calculations.db