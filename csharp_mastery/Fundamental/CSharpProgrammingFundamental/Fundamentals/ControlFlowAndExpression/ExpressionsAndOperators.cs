using CSharpFundamentals.DataTypes;
using Microsoft.VisualBasic;
using OpenQA.Selenium.DevTools.V113.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._03_Fundamentals.ControlFlowAndExpression
{
    class LimitedInt
    {
        const int MaxValue = 100;
        const int MinValue = 0;

        public static implicit operator int(LimitedInt li)       // Convert type
        {
            return li.TheValue;
        }

        public static implicit operator LimitedInt(int x)        // Convert type
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x;
            return li;
        }

        public static LimitedInt operator -(LimitedInt x)
        {
            // In this strange class, negating a value just sets its value to 0.
            LimitedInt li = new LimitedInt();
            li.TheValue = 0;
            return li;
        }

        public static LimitedInt operator -(LimitedInt x, LimitedInt y)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x.TheValue - y.TheValue;
            return li;
        }

        public static LimitedInt operator +(LimitedInt x, double y)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x.TheValue + (int)y;
            return li;
        }

        private int mTheValue = 0;
        public int TheValue
        { // Property
            get { return mTheValue; }
            set
            {
                if (value < MinValue)
                    mTheValue = 0;
                else
                    mTheValue = value > MaxValue
                          ? MaxValue
                          : value;
            }
        }
    }

    class OtherLimitedInt
    {
        const int MaxValue = 100;
        const int MinValue = 0;

        public static explicit operator int(OtherLimitedInt li)
        {
            return li.TheValue;
        }

        public static explicit operator OtherLimitedInt(int x)
        {
            OtherLimitedInt li = new OtherLimitedInt();
            li.TheValue = x;
            return li;
        }

        private int mTheValue = 0;
        public int TheValue
        { // Property
            get { return mTheValue; }
            set
            {
                if (value < MinValue)
                    mTheValue = 0;
                else
                    mTheValue = value > MaxValue
                          ? MaxValue
                          : value;
            }
        }
    }

    public struct MyType // Run twice; once as a struct and again as a class.
    {
        public int X;
        public MyType(int x)
        {
            X = x;
        }
        public static MyType operator ++(MyType m)
        {
            m.X++;
            return m;
        }
    }

    class SomeClass
    {
        public int Field1;
        public int Field2;
        public void Method1() { }
        public int Method2() { return 1; }
    }


    [TestFixture]
    public class ExpressionsAndOperators
    {
        [Test]
        public void Literals()
        {
            Console.WriteLine("{0}", 1024);        // int literal
            Console.WriteLine("{0}", 3.1416);      // double literal
            Console.WriteLine("{0}", 3.1416F);     // float literal
            Console.WriteLine("{0}", true);        // boolean literal
            Console.WriteLine("{0}", 'x');         // character literal
            Console.WriteLine("{0}", "Hi there");  // string literal
        }

        [Test]
        public void StringLiterals()
        {
            string rst1 = "Hi there!";
            string vst1 = @"Hi there!";
            string rst2 = "It started, \"Four score and seven...\"";
            string vst2 = @"It started, ""Four score and seven...""";
            string rst3 = "Value 1 \t 5, Val2 \t 10";             // Interprets tab esc sequence
            string vst3 = @"Value 1 \t 5, Val2 \t 10";            // Does not interpret tab
            string rst4 = "C:\\Program Files\\Microsoft\\";
            string vst4 = @"C:\Program Files\Microsoft\";
            string rst5 = " Print \x000A Multiple \u000A Lines";
            string vst5 = @" Print
                             Multiple
                             Lines";

            Console.WriteLine(rst1);
            Console.WriteLine(vst1);
            Console.WriteLine();

            Console.WriteLine(rst2);
            Console.WriteLine(vst2);
            Console.WriteLine();

            Console.WriteLine(rst3);
            Console.WriteLine(vst3);
            Console.WriteLine();

            Console.WriteLine(rst4);
            Console.WriteLine(vst4);
            Console.WriteLine();

            Console.WriteLine(rst5);
            Console.WriteLine();

            Console.WriteLine(vst5);
        }

        [Test]
        public void RemainderOperator()
        {
            Console.WriteLine("0.0f % 1.5f is {0}", 0.0f % 1.5f);
            Console.WriteLine("0.5f % 1.5f is {0}", 0.5f % 1.5f);
            Console.WriteLine("1.0f % 1.5f is {0}", 1.0f % 1.5f);
            Console.WriteLine("1.5f % 1.5f is {0}", 1.5f % 1.5f);
            Console.WriteLine("2.0f % 1.5f is {0}", 2.0f % 1.5f);
            Console.WriteLine("2.5f % 1.5f is {0}", 2.5f % 1.5f);
        }

        [Test]
        public void RelationalAndEqualityComparisonOperators()
        {
            int x = 5, y = 4;
            Console.WriteLine($"x == x is {x == x}");
            Console.WriteLine($"x == y is {x == y}");
        }

        [Test]
        public void IncrementAndDecrementOperators()
        {
            int x = 5, y;
            y = x++;    // result: y: 5, x: 6
            Console.WriteLine($"y: {y}, x: {x}");

            x = 5;
            y = ++x;    // result: y: 6, x: 6
            Console.WriteLine($"y: {y}, x: {x}");

            x = 5;
            y = x--;    // result: y: 5, x: 4
            Console.WriteLine($"y: {y}, x: {x}");

            x = 5;
            y = --x;    // result: y: 4, x: 4
            Console.WriteLine($"y: {y}, x: {x}");
        }

        [Test]
        public void ShiftOperators()
        {
            int a, b, x = 14;

            a = x << 3;    // Shift left
            b = x >> 3;    // Shift right

            Console.WriteLine($"{x} << 3 = {a}");
            Console.WriteLine($"{x} >> 3 = {b}");
        }

        [Test]
        public void ConditionalOperator()
        {
            int x = 10, y = 9;
            int highVal = x > y                          // Condition
                     ? x                                 // Expression 1
                     : y;                                // Expression 2
            Console.WriteLine($"highVal: {highVal}\n");

            Console.WriteLine("x is{0} greater than y",
                     x > y                               // Condition
                        ? ""                             // Expression 1
                        : " not");                       // Expression 2
            y = 11;
            Console.WriteLine("x is{0} greater than y",
                     x > y                               // Condition
                        ? ""                             // Expression 1
                        : " not");                       // Expression 2   }
        }

        [Test]
        public void UserDefinedTypeConversions()
        {
            LimitedInt li = 500;                                  // Convert 500 to LimitedInt
            int value = li;                                       // Convert LimitedInt to int
            Console.WriteLine($"li: {li.TheValue}, value: {value}");
        }

        [Test]
        public void ExplicitConversionAndTheCastOperator()
        {
            OtherLimitedInt li = (OtherLimitedInt)500;
            int value = (int)li;

            Console.WriteLine($"li: {li.TheValue}, value: {value}");

        }

        [Test]
        public void OperatorOverloading()
        {
            LimitedInt li1 = new LimitedInt();
            LimitedInt li2 = new LimitedInt();
            LimitedInt li3 = new LimitedInt();

            li1.TheValue = 10; li2.TheValue = 26;
            Console.WriteLine($" li1: {li1.TheValue}, li2: {li2.TheValue}");

            li3 = -li1;
            Console.WriteLine($"-{li1.TheValue} = {li3.TheValue}");

            li3 = li2 - li1;
            Console.WriteLine($" {li2.TheValue} - {li1.TheValue} = {li3.TheValue}");

            li3 = li1 - li2;
            Console.WriteLine($" {li1.TheValue} - {li2.TheValue} = {li3.TheValue}");
        }

        [Test]
        public void IncrementDecrementOperator()
        {
            MyType tv = new MyType(10);
            Console.WriteLine("Pre-increment");
            Show("Before   ", tv);
            Show("Returned ", ++tv);
            Show("After    ", tv);
            Console.WriteLine();

            tv = new MyType(10);
            Console.WriteLine("Post-increment");
            Show("Before   ", tv);
            Show("Returned ", tv++);
            Show("After    ", tv);
        }

        static void Show(string message, MyType tv)
        {
            Console.WriteLine($"{message} {tv.X}");
        }

        [Test]
        public void TypeofOperator()
        {
            Type t = typeof(SomeClass);
            FieldInfo[] fi = t.GetFields();
            MethodInfo[] mi = t.GetMethods();

            foreach (FieldInfo f in fi)
                Console.WriteLine($"Field : {f.Name}");
            foreach (MethodInfo m in mi)
                Console.WriteLine($"Method: {m.Name}");
        }

        [Test]
        public void GetType()
        {
            SomeClass s = new SomeClass();
            Console.WriteLine($"Type s: {s.GetType().Name}");
        }
    }
}
