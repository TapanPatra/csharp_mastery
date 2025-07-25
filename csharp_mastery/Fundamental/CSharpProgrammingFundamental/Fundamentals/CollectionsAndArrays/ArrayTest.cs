using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CSharpFundamental.Fundamentals.CollectionsAndArrays
{
    [TestFixture]
    public class ArrayTest
    {
        class MyClass
        {
            public int MyField = 0;
        }

        class A
        {
            public int Value = 5;
        } // Base class
        class B : A
        {
        } // Derived class


        [Test]
        public void AccessingArrayElementsExample()
        {
            int[] myIntArray;                      // Declare the array.

            myIntArray = new int[4];               // Instantiate the array.

            for (int i = 0; i < 4; i++)          // Set the values.
                myIntArray[i] = i * 10;

            // Read and display the values of each element.
            for (int i = 0; i < 4; i++)
                Console.WriteLine($"Value of element {i} = {myIntArray[i]}");
        }

        [Test]
        public void InitializingArray()
        {
            // Declare, create, and initialize an implicitly typed array.
            var arr = new int[,] { { 0, 1, 2 }, { 10, 11, 12 } };

            // Print the values.
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++)
                    Console.WriteLine($"Element [{i},{j}] is {arr[i, j]}");
        }

        [Test]
        public void JaggedArrays()
        {
            int[][,] Arr;           // An array of 2D arrays
            Arr = new int[3][,];    // Instantiate an array of three 2D arrays.

            Arr[0] = new int[,] { { 10, 20 },
                            { 100, 200 } };
            Arr[1] = new int[,] { { 30, 40, 50 },
                            { 300, 400, 500 } };
            Arr[2] = new int[,] { { 60, 70, 80, 90 },
                            { 600, 700, 800, 900 } };

            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr[i].GetLength(0); j++)
                {
                    for (int k = 0; k < Arr[i].GetLength(1); k++)
                    {
                        Console.WriteLine($"[{i}][{j},{k}] = {Arr[i][j, k]}");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
        }

        [Test]
        public void ForeachStatementToPrintArray()
        {
            int[] arr1 = { 10, 11, 12, 13 };
            foreach (int item in arr1)
                Console.WriteLine($"Item Value: {item}");
        }

        [Test]
        public void ArrayOfReferenceType()
        {
            MyClass[] mcArray = new MyClass[4];             // Create array.
            for (int i = 0; i < 4; i++)
            {
                mcArray[i] = new MyClass();                  // Create class objects.
                mcArray[i].MyField = i;                      // Set field.
            }

            foreach (MyClass item in mcArray)
                item.MyField += 10;                          // Change the data.

            foreach (MyClass item in mcArray)
                Console.WriteLine($"{item.MyField}");    // Read the changed data.
        }

        [Test]
        public void RectangularArrayExample()
        {
            int total = 0;
            int[,] arr1 = { { 10, 11 }, { 12, 13 } };

            foreach (var element in arr1)
            {
                total += element;
                Console.WriteLine($"Element: {element}, Current Total: {total}");
            }
        }

        [Test]
        public void JaggedArrayExample()
        {
            int total = 0;
            int[][] arr1 = new int[2][];
            arr1[0] = new int[] { 10, 11 };
            arr1[1] = new int[] { 12, 13, 14 };

            foreach (int[] array in arr1)           // Process the top level.
            {
                Console.WriteLine("Starting new array");
                foreach (int item in array)          // Process the second level.
                {
                    total += item;
                    Console.WriteLine($" Item: {item}, Current Total: {total}");
                }
            }
        }

        [Test]
        public void ArrayCovariance()
        {
            A[] AArray1 = new A[3]; // Two arrays of type A[]
            A[] AArray2 = new A[3]; //
                                    // Normal--assigning objects of type A to an array of type A
            AArray1[0] = new A(); AArray1[1] = new A(); AArray1[2] = new A();
            // Covariant--assigning objects of type B to an array of type A
            AArray2[0] = new B(); AArray2[1] = new B(); AArray2[2] = new B();
        }

        [Test]
        public void ArrayPropotiesAndMethods()
        {
            int[] arr = new int[] { 15, 20, 5, 25, 10 };
            PrintArray(arr);
            Array.Sort(arr);
            PrintArray(arr);
            Array.Reverse(arr);
            PrintArray(arr);
            Console.WriteLine();
            Console.WriteLine($"Rank = {arr.Rank}, Length = {arr.Length}");
            Console.WriteLine($"GetLength(0) = {arr.GetLength(0)}");
            Console.WriteLine($"GetType() = {arr.GetType()}");
        }

        public static void PrintArray(int[] a)
        {
            foreach (var x in a)
                Console.Write($"{x} ");
            Console.WriteLine("");
        }

        [Test]
        public void ArrayClone()
        {
            int[] intArr1 = { 1, 2, 3 }; // Step 1
            int[] intArr2 = (int[])intArr1.Clone(); // Step 2
            intArr2[0] = 100; intArr2[1] = 200; intArr2[2] = 300; // Step 


            //Cloning a reference type array produces two arrays referencing same object
            A[] AArray1 = new A[3] { new A(), new A(), new A() }; // Step 1
            A[] AArray2 = (A[])AArray1.Clone(); // Step 2
            AArray2[0].Value = 100;
            AArray2[1].Value = 200;
            AArray2[2].Value = 300; // Step 3

        }

        [Test]
        public void ArrayAsParameter()
        {
            int[] scores = { 5, 80 };
            Console.WriteLine($"Before: {scores[0]}, {scores[1]}");
            ref int locationOfHigher = ref PointerToHighestPositive(scores);

            locationOfHigher = 0;               // Change the value through ref local
            Console.WriteLine($"After : {scores[0]}, {scores[1]}");
        }

        public static ref int PointerToHighestPositive(int[] numbers)
        {
            int highest = 0;
            int indexOfHighest = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > highest)
                {
                    indexOfHighest = i;
                    highest = numbers[indexOfHighest];
                }
            }
            return ref numbers[indexOfHighest];
        }



        [Test]
        public void Print_Any_That_Appear_in_BothArray()
        {
            /*
            2 arrays. Print any that appear in both
            Example:
            a1 = {'c', 'a', 'b', 'c'}
            a2 = {'b', 'c', 'd'}
 
            Expected Result: {'b', 'c'}
            */
            char[] a = new char[] { 'a', 'a', 'a', 'a' };
            char[] b = new char[] { 'a', 'a', 'a' };
            PrintDups(a, b);

        }

        private void PrintDups(char[] a, char[] b)
        {
            Dictionary<char, int> aMap = new Dictionary<char, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!aMap.ContainsKey(a[i]))
                {
                    aMap.Add(a[i], 1);
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (aMap.ContainsKey(b[i]))
                {
                    Console.WriteLine(b[i]);
                    if (aMap[b[i]] == 1)
                    {
                        aMap.Remove(b[i]);
                    }
                }

            }

        }
    }

}
