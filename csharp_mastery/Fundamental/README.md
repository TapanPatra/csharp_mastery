# C# Foundations
Here is a quick run down of the lessons found in the foundations folder.
## Learning Resource
  - [The Ultimate C# Mastery Series by Code with Mosh](https://codewithmosh.com/p/the-ultimate-csharp-mastery-series)
  - [Book Illustrated C# 7](https://www.amazon.com/Illustrated-Language-Presented-Concisely-Visually/dp/1484232879)
  - [Pluralsight Course Mastering C# 4.0 by Jon Skeet](https://app.pluralsight.com/library/courses/skeet-csharp4/)
  - [C# Cheat Sheet](https://zerotomastery.io/cheatsheets/csharp-cheat-sheet/)

## Table of Contents

- [Introduction](#Basics)
- [Variables](#Variables)
- [ConditionalStatements](#ConditionalStatements)
- [Loops](#Loops)
- [Classes](#Classes)
- [ExtensionMethods](#ExtensionMethods)
- [ExceptionHandling](#ExceptionHandling)
- [Structs](#Structs)
- [Interfaces](#Interfaces)
- [Arrays](#Arrays)
- [Indexers,Enumerators,Iterators](#Indexers,Enumerators,Iterators)
- [Linq](#Linq)
- [Collection](#Collection)



## Basics

### Basic structure
```csharp
using System; // 'using' allows for easier access to types in a namespace. namespace YourNamespace
// Namespaces organize code and prevent
naming collisions.
{
  class YourClass // A 'class' defines the blueprint of objects.
  {
    static void Main(string[] args) // 'Main' is where the program
    starts execution.
    {
      Console.WriteLine("Hello, World!"); // Displays text in the console.
    }
  }
}
 ```

### Data Types
Every variable and constant in C# has a type, determining the values it can hold and operations that can be performed on it.
- Reference Types: Store a memory address. They point to the address of the value
  - string, class, array are commlonly used.
- Value Types:Directly store the data. Once you assign a value, it holds that data.
  - int,char,float are just a few examples.

### Variables
```csharp
int num = 5; // Declares an integer variable and assigns it the value 5.
string word = "Hello"; // Declares a string variable and assigns it the value "Hello".
// We can use var because the compiler knows that "..." is a string
var name = "Peter";
// We can use var because we state that we create a new object of type Person.
var person = new Person();
```
The var keyword helps us keep the code short and improves readability

### Constants
Constants are immutable. Once their value is set cannot be cahnged.
```csharp
const int ConstNum = 5; //The value of ConstNum always be 5.
```
**Hint:** Constants follow Pascal Case.
### Conditional Statements
```csharp
if (condition) { /*...*/ } // Executes if 'condition' is true.
else if (condition) { /*...*/ } // Additional conditions if the above ones fail.
else { /*...*/ } // Executes if no conditions are met

switch (variable) // Useful when comparing a single variable to many values.
{
  case value1:
    // Code for value1
    break; // Exits the switch statement.
    // ... other cases ...
    default:
    // Executes if no other case matches.
    break;
}
```
### Loops
```csharp
for (int i = 0; i < 10; i++) { /*...*/ } // Loops 10 times, incrementing 'i' each time.
foreach (var item in collection) { /*...*/ } // Loops over each item in 'collection'.
while (condition) { /*...*/ } // Continues looping as long as 'condition' remains true.
do { /*...*/ } while (condition); // Executes once before checking 'condition'
```
### Methods
```csharp
public returnType MethodName(parameters) { /*...*/ } // A method's signature.
// A Sum method returning int with two int parameters.
public int Sum(int a, int b)
{
  return a + b;
}
```

## Classes
```csharp
public class MyClass
{
  public string PropertyName { get; set; } // Properties store data for an object.
  public void MethodName() { /*...*/ } // Methods define actions an object can take.
}
MyClass obj = new MyClass(); // Creates a new object of type 'MyClass'.
```
Hint:Auto-properties (as used in the example above), tell the compiler to create a
backing field. We do not have to create the backing field and fill it within the Set method
or get the value within the Get method. However, we can still implement custom logic when required
### Extension Methods
Add new methods to existing types without altering them.
```csharp
public static class StringExtensions
{
  public static bool IsNullOrEmpty(this string str)
  {
    return string.IsNullOrEmpty(str);
  }
}
```
### Partial Classes
Allows the splitting of a single class definition over multiple files or sections in the samefile
```csharp
public partial class MyClass
{
  public void MethodOne() { /*...*/ }
}
public partial class MyClass
{
  public void MethodTwo() { /*...*/ }
}
```
## Exception Handling
A mechanism to handle runtime errors gracefully, ensuring the program continues or fails gracefully
```csharp
try
{
  // Code that might throw an exception.
}
catch (SpecificException ex) // Catches specific exceptions, allowing tailored responses.
{
  // Handle this specific error.
}
finally
{
  // Cleanup code. Executes regardless of whether an exception was thrown.
}
```
Hint:It’s best practice to catch an exception with a specific type (e.g. SqlException) and
have a single general fallback try-catch to catch exceptions of type Exception

## Structs
```csharp
struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Display()
    {
        Console.WriteLine($"Point is at ({X}, {Y})");
    }
}
Point p1 = new Point(10, 20);
p1.Display();
```

## Interfaces
```csharp
interface IShape
{
    double GetArea();
    void Display();
}

class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public void Display()
    {
        Console.WriteLine($"Circle with radius: {Radius}, Area: {GetArea()}");
    }
}

IShape circle = new Circle(5);
circle.Display();
```

## Arrays
Fixed-size collections that hold elements of the same type.
```csharp
int[] numbers = new int[5] {1, 2, 3, 4, 5}; // Declares an array of integers
```
## String
```csharp
string.Concat(); // Combines multiple strings.
string.Join(); // Joins elements with a separator.
str.Split(); // Splits a string based on delimiters.
str.ToUpper(); // Converts to uppercase.
str.ToLower(); // Converts to lowercase.
str.Trim(); // Removes leading and trailing whitespace.
str.Substring(); // Extracts a portion of the string
```
## Properties
```csharp
class Person
{
    // Private fields
    private string name;
    private int age;

    // Public property for Name with get and set accessors
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Public property for Age with get and set accessors
    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
                age = value;
            else
                throw new ArgumentOutOfRangeException("Age cannot be negative");
        }
    }

    // Auto-implemented property for City
    public string City { get; set; }

    // Constructor
    public Person(string name, int age, string city)
    {
        Name = name;
        Age = age;
        City = city;
    }

    // Method to display person details
    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, City: {City}");
    }
}

// Creating an instance of the Person class
Person person = new Person("Alice", 30, "New York");
// Displaying initial values
person.Display();
// Modifying properties
person.Name = "Bob";
person.Age = 35;
person.City = "Los Angeles";
```
## Generic Types
Generics allow for type-safe data structures without compromising type integrity or performance
```csharp
public class MyGenericClass<T> // 'T' is a placeholder for anytype.
{
  private T item;
  public void UpdateItem(T newItem)
  {
    item = newItem;
  }
}
```

## Indexers, Enumerators, Iterators
### Indexers 
Indexers allow instances of a class or struct to be indexed just like arrays.
### Enumerators 
Enumerators are used to iterate over a collection.
###  Iterators
Iterators simplify the implementation of custom collection classes by allowing the use of yield return
```csharp
class CustomCollection<T> : IEnumerable<T>
{
    private List<T> items = new List<T>();

    // Indexer to access elements
    public T this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    // Add method to add elements
    public void Add(T item)
    {
        items.Add(item);
    }

    // Implementing GetEnumerator for IEnumerable<T>
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    // Explicit implementation of IEnumerable.GetEnumerator
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Custom iterator method using yield return
    public IEnumerable<T> Reverse()
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            yield return items[i];
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CustomCollection<string> collection = new CustomCollection<string>();

        // Adding items to the collection
        collection.Add("First");
        collection.Add("Second");
        collection.Add("Third");

        // Using the indexer
        Console.WriteLine("Item at index 1: " + collection[1]);

        // Modifying an item using the indexer
        collection[1] = "Modified Second";
        Console.WriteLine("Modified item at index 1: " + collection[1]);

        // Iterating using foreach (enumerator)
        Console.WriteLine("Iterating over collection:");
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }

        // Using the custom iterator method
        Console.WriteLine("Iterating over collection in reverse:");
        foreach (var item in collection.Reverse())
        {
            Console.WriteLine(item);
        }
    }
}
```
## Enumerations
```csharp
public enum DaysOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
DaysOfWeek today = DaysOfWeek.Monday;
```

## Attributes
Add metadata to your code. This metadata can be inspected at runtime.
```csharp
[Obsolete("This method is deprecated.")] // An attribute warning developers about deprecated methods.
public void OldMethod() { /*...*/ }
```
## Attributes & Reflection
Attributes provide metadata about program entities, while reflection allows introspection into types at runtime
```csharp
[MyCustomAttribute] // Custom attribute applied to a class.
public class MyClass
{
  //...
}
// Using reflection to get the attribute:
Attribute[] attrs = Attribute.GetCustomAttributes(typeof(MyClass));
```

## Delegates, Anonymous Methods, and Lambdas
Essential for event-driven programming and for treating methods as first-class citizens
```csharp
// A type that represents methods with a specific signature.
public delegate void MyDelegate();
// An event that can be triggered when certain actions occur.
event MyDelegate MyEvent;
Func<int, int, int> add = (a, b) => a + b; // Lambda expression. A concise way to define methods
```
## Linq 
Introduces native query capabilities into C#, making data manipulation simpler and more readable
```csharp
using System.Linq; // Required for LINQ queries.
var result = from s in list where s.Contains("test") select s; // Sample query to filter data.
```

## Collection
### Lists
Like arrays, but can dynamically change in size.
```csharp
using System.Collections.Generic; // Required namespace for Lists.
List<int> list = new List<int>() {1, 2, 3, 4, 5}; // Initializes a List with 5 integers.
list.Add(6); // Add the number 6 to the list
list.Remove(2) // Remove the element at index 2 (0-based) from the list.
```
### Dictionaries
Associative containers that store key-value pairs
```csharp
using System.Collections.Generic;
Dictionary<string, int> dict = new Dictionary<string, int>()
{
  {"one", 1}, // "one" is the key, 1 is its associated value.
  {"two", 2}
};
dict.Add("key", "value"); // Add a new item to the dictionary.
dict["key"] // Access the value of the dictionary at the key 'key'
```


## Threading
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Creating a new thread
        Thread thread = new Thread(DoWork);

        // Starting the thread
        thread.Start();

        // Main thread continues its work
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Main thread is working...");
            Thread.Sleep(1000); // Simulate work
        }

        // Waiting for the thread to finish
        thread.Join();

        Console.WriteLine("Main thread exiting.");
    }

    static void DoWork()
    {
        // Simulating some work
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Worker thread is working...");
            Thread.Sleep(2000); // Simulate work
        }

        Console.WriteLine("Worker thread finished.");
    }
}
```

## Asynchronous and Parallel Programming
Modern mechanism for writing non-blocking (asynchronous) code, especially useful for I/O-bound operations.
```csharp
public async Task<returnType> MethodName()
{
  return await OtherAsyncMethod(); // 'await' pauses method execution until the awaited task completes.
}
```

## Dependency Injection
A software design pattern that facilitates loosely coupled code, improving maintainability and testability
```csharp
public interface IService
{
  void DoSomething();
}
public class MyService : IService
{
  public void DoSomething()
  {
  // Implementation here
  }
}
public class Consumer
{
  private readonly IService _service;
  public Consumer(IService service)
  {
    _service = service; // Dependency injection through constructor
  }
}
//Register services to the internal dependency injection container in the Program.cs file
builder.Services.AddScoped<IService, MyService>();
```
## Interoperability
C# allows interoperability with other languages, particularly with legacy Win32API functions
```csharp
using System.Runtime.InteropServices; // Required for DllImport.
[DllImport("user32.dll")]
public static extern int MessageBox(IntPtr h, string m, string c, int type);
```
## Anonymous Types
Allows creation of unnamed types with automatic property definition.
```csharp
var anon = new { Name = "John", Age = 25 }; // The type of 'anon' is inferred at compile time
```
## Pattern Matching
```csharp
object obj = "hello";
if (obj is string str)
{
  Console.WriteLine(str); // str is "hello"
}
```
## Local Functions
Functions can be defined within methods, allowing for encapsulation of logic without polluting class or namespace scopes.
```csharp
public void MyMethod()
{
  void LocalFunction()
  {
    // Implementation
  }
LocalFunction(); // Calling the local function
}
```
## Records
Records provide a concise syntax for reference types with value semantics for equality. They're immutable and are great for data structures
```csharp
public record Person(string Name, int Age);
```

## Tuples
Tuples are data structures that have a specific number and sequence of elements
```csharp
var person = Tuple.Create("John", 25); // Creates a tuple with two items.
```
## with Expressions
Used with records to create a non-destructive mutation.
```csharp
var john = new Person("John", 30);
var jane = john with { Name = "Jane" }; // jane is now ("Jane",30)
```
##  Indexers and Ranges
Allow for more flexible data access, especially useful with strings, arrays, and lists
```csharp
int[] arr = {0, 1, 2, 3, 4, 5};
var subset = arr[1..^1]; // Grabs elements from index 1 to the second to last
```
## using Declaration
A more concise way to ensure IDisposable objects are properly disposed.
```csharp
using var reader = new StreamReader("file.txt"); // reader is disposed of at the end of the enclosing scope.
```
## Nullable Reference Type
A feature to help avoid null reference exceptions by being explicit about reference type nullability
```csharp
#nullable enable
string? mightBeNull; // Reference type that might be null
```
## Nullables
C# allows value types to be set to null using nullable types.
```csharp
int? nullableInt = null; // '?' makes the int nullable.
bool hasValue = nullableInt.HasValue; // Checks if nullable type has a value
```
## Pattern-Based Using
Allows for more patterns in the using statement without implementing IDisposable
```csharp
public ref struct ResourceWrapper
{
  public void Dispose()
  {
    // Cleanup
  }
}
using var resource = new ResourceWrapper();
```
## Property Patterns
Facilitates deconstruction of objects in pattern matching.
```csharp
if (obj is Person { Name: "John", Age: var age })
{
  Console.WriteLine($"John's age is {age}");
}
```
## Default Interface Implementations
Interfaces can provide default method implementations.
```csharp
public interface IPerson
{
  void Display();
  void Greet() => Console.WriteLine("Hello!"); // Default impleme  ntation.
}
```
## Dynamic Binding
Makes use of the DLR (Dynamic Language Runtime) for runtime type resolution.
```csharp
dynamic d = 5;
d = "Hello"; // No compile-time type checking
```
## File I/O
Interactions with the filesystem are common tasks. C# makes reading from and writing to files straightforward.
```csharp
using System.IO; // Necessary for most File I/O operations.
File.ReadAllText(path); // Reads the entire content of a file into a string.
File.WriteAllText(path, content); // Writes a string to a file,creating or overwriting it.
File.Exists(path); // Checks if a file exists at the specifiedpath
```
## Date & Time
```csharp
DateTime current = DateTime.Now; // Gets the current date and time.
current.AddDays(1); // Adds a day to the current date.
current.ToShortDateString(); // Converts the date to a short date string format.
```



