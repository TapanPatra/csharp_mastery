using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public class MyClass
    {
        public int Val = 20; // Initialize the field to 20.
    }


    [TestFixture]
    public class MethodsTest
    {
        int Factorial(int inValue)
        {
            if (inValue <= 1)
                return inValue;
            else
                return inValue * Factorial(inValue - 1); // Call Factorial again.
        }

        [Test]
        public void RecursionTest()
        {
            Console.WriteLine("{0}", Factorial(5));
        }

        static void MethodA(int par1, int par2)
        {
            Console.WriteLine("Enter MethodA: {0}, {1}", par1, par2);
            MethodB(11, 18); // Call MethodB.
            Console.WriteLine("Exit MethodA");
        }
        static void MethodB(int par1, int par2)
        {
            Console.WriteLine("Enter MethodB: {0}, {1}", par1, par2);
            Console.WriteLine("Exit MethodB");
        }

        [Test]
        public void StackFramesTest()
        {
            Console.WriteLine("Enter StackFramesTest");
            MethodA(15, 30); // Call MethodA.
            Console.WriteLine("Exit StackFramesTest");
        }

        [Test]
        public void OptionalParametersTest()
        {
            Console.WriteLine(Sum(5));
            Console.WriteLine(Sum(5,6));
        }

        public int Sum(int a, int b = 3)
        {
            return a + b; //Default value assignment
        }

        [Test]
        public void NamedParametersTest()
        {
            Console.WriteLine(Calc(c: 2, a: 4, b: 3));
        }

        public int Calc(int a, int b, int c)
        {
            return (a + b) * c;
        }

        [Test]
        public void MethodOverloadingTest()
        {
             Console.WriteLine(AddValues(10, 20));
        }

        long AddValues(int a, int b) { return a + b; }
        long AddValues(int c, int d, int e) { return c + d + e; }
        long AddValues(float f, float g) { return (long)(f + g); }
        long AddValues(long h, long m) { return h + m; }


        [Test]
        public void ParameterArraysTest()
        {
            int[] intArray = { 1, 2, 3 };
            ListInts(intArray);
            ListInts(); // 0 actual parameters
            ListInts(1, 2, 3); // 3 actual parameters
            ListInts(4, 5, 6, 7);
        }

        void ListInts(params int[] inVals)
        {
            if ((inVals != null) && (inVals.Length != 0))
                for (int i = 0; i < inVals.Length; i++) // Process the array.
                {
                    inVals[i] = inVals[i] * 10;
                    Console.WriteLine($"{inVals[i]}"); // Display new value.
                }
        }
        static void MyMethod(out MyClass f1, out int f2)
        {
            f1 = new MyClass(); // Create an object of the class.
            f1.Val = 25; // Assign to the class field.
            f2 = 15; // Assign to the int param.
        }


        [Test]
        public void OutputParametersTest()
        {
            MyClass a1 = null;
            int a2;
            MyMethod(out a1, out a2); // Call the method.
        }

        static void RefAsParameter(MyClass f1)
        {
            f1.Val = 50;
            Console.WriteLine("After member assignment: {0}", f1.Val);
            f1 = new MyClass();
            Console.WriteLine("After new object creation: {0}", f1.Val);
        }

        static void RefAsParameter(ref MyClass f1)
        {
            // Assign to the object member.
            f1.Val = 50;
            Console.WriteLine("After member assignment: {0}", f1.Val);
            // Create a new object and assign it to the formal parameter.
            f1 = new MyClass();
            Console.WriteLine("After new object creation: {0}", f1.Val);
        }


        [Test]
        public void ReferenceTypesAsValueAndReferenceParametersTest()
        {
            MyClass a1 = new MyClass();
            Console.WriteLine("Before method call: {0}", a1.Val);
            RefAsParameter(a1);
            Console.WriteLine("After method call: {0}", a1.Val);

            MyClass b1 = new MyClass();
            Console.WriteLine("Before method call: {0}", b1.Val);
            RefAsParameter(ref b1);
            Console.WriteLine("After method call: {0}", b1.Val);

        }


        static void MyMethod(MyClass f1, int f2)
        {
            f1.Val = f1.Val + 5; // Add 5 to field of f1 param.
            f2 = f2 + 5; // Add 5 to second param.
            Console.WriteLine("f1.Val: {0}, f2: {1}", f1.Val, f2);
        }

        static void MyRefMethod(ref MyClass f1, ref int f2)
        {
            f1.Val = f1.Val + 5; // Add 5 to field of f1 param.
            f2 = f2 + 5; // Add 5 to second param.
            Console.WriteLine("f1.Val: {0}, f2: {1}", f1.Val, f2);
        }

        [Test]
        public void ReferenceParametersTest()
        {
            MyClass a1 = new MyClass();
            int a2 = 10;

            MyRefMethod(ref a1, ref a2); // Call the method.
            Console.WriteLine("f1.Val: {0}, f2: {1}", a1.Val, a2);
        }


        [Test]
        public void ValueParametersTest()
        {
            MyClass a1 = new MyClass();
            int a2 = 10;
            MyMethod(a1, a2); // Call the method.
            Console.WriteLine("f1.Val: {0}, f2: {1}", a1.Val, a2);

        }

        public void PrintSum(int x, int y)
        {
            int sum = x + y;
            Console.WriteLine("Newsflash: {0} + {1} is {2}", x, y, sum);
        }

        [Test]
        public void ParametersTest()
        {
            PrintSum(5, 10);
        }



    }

}
