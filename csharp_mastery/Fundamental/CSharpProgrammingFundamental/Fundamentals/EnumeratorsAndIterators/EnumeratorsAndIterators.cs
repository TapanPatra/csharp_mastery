using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fundamentals
{
    class ColorEnumerator : IEnumerator
    {
        string[] Colors;
        int Position = -1;

        public ColorEnumerator(string[] theColors) // Constructor
        {
            Colors = new string[theColors.Length];
            for (int i = 0; i < theColors.Length; i++)
                Colors[i] = theColors[i];
        }

        public object Current // Implement Current.
        {
            get
            {
                if (Position == -1)
                    throw new InvalidOperationException();

                if (Position >= Colors.Length)
                    throw new InvalidOperationException();

                return Colors[Position];
            }
        }

        public bool MoveNext() // Implement MoveNext.
        {
            if (Position < Colors.Length - 1)
            {
                Position++;
                return true;
            }
            else
                return false;
        }

        public void Reset() // Implement Reset.
        {
            Position = -1;
        }
    }

    class Spectrum : IEnumerable
    {

        string[] Colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };



        public IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(Colors);
        }

        public IEnumerable<string> UVtoIR()
        {
            for (int i = 0; i < Colors.Length; i++)
                yield return Colors[i];
        }

        public IEnumerable<string> IRtoUV()
        {
            for (int i = Colors.Length - 1; i >= 0; i--)
                yield return Colors[i];
        }
    }
    
    
    [TestFixture]
   public class EnumeratorsAndIterators
    {
        class MyClassEnumerator
        {
            public IEnumerator<string> GetEnumerator()       // Returns the enumerator
            {
                return BlackAndWhite();

            }

            public IEnumerator<string> BlackAndWhite()      // Iterator
            {
                yield return "black";
                yield return "gray";
                yield return "white";
            }
        }

        class MyClassEnumerable
        {
            public IEnumerator<string> GetEnumerator()
            {
                IEnumerable<string> myEnumerable = BlackAndWhite(); // Get enumerable.
                return myEnumerable.GetEnumerator(); // Get enumerator.
            }

            public IEnumerable<string> BlackAndWhite()
            {
                yield return "black";
                yield return "gray";
                yield return "white";
            }
        }


        public static readonly int[] seeds = { 10, 20 };

        public class Fred<T>
        {
            readonly T greeting;

            public Fred(T greeting)
            {
                this.greeting = greeting;
            }

            public T Foo()
            {
                return greeting;
            }

        }


        [Test]
        public void ArrayIterationSimulateForEach()
        {
            int[] array = new int[] { 3, 5, 7 };
            DisplayContent(array);
        }

        [Test]
        public void ListIterationSimulateForEach()
        {
            List<string> list = new List<string>() { "a", "b", "c" };
            DisplayContent(list);
        }

        private void DisplayContent<T> (IEnumerable<T> collection)
        {
            using (IEnumerator<T> iterator = collection.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    Console.WriteLine(iterator.Current);
                }

            }
        }

        [Test]
        public void ArrayBasics()
        {
            int[] array = new int[5];
            array[0] = 10;
            int value = array[0];

            Assert.AreEqual(10, value);

            Assert.AreEqual(5, array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0} : {1}", i, array[i]);
            }

            foreach (int tmp in array)
            {
                Console.WriteLine(tmp);
            }

            IEnumerable<int> sequence = array;

            foreach (var tmp in array)
            {
                Console.WriteLine(tmp);
            }


        }

        [Test]
        public void ArrayMutability()
        {
            seeds[0] = 30;
            Console.WriteLine(seeds[0]);

        }

        [Test]
        public void ListBasic()
        {
            List<string> names = new List<string>();

            names.Add("fred");
            Assert.AreEqual("fred", names[0]);

            Assert.AreEqual(1, names.Count);
            names.Add("betty");
            Assert.AreEqual(2, names.Count);

            names.RemoveAt(0);
            Assert.AreEqual(1, names.Count);
            Assert.AreEqual("betty", names[0]);

            names[0] = "banny";
            Assert.AreEqual("banny", names[0]);

            var integers = new List<int>() { 10, 20 };
            Assert.AreEqual(2, integers.Count);
        }

        [Test]
        public void DictionaryBasaics()
        {
            var map = new Dictionary<string, int>();

            map.Add("foo", 10);
            map["bar"] = 20;

            foreach (var item in map)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }

            int value;

            bool keyFound = map.TryGetValue("bla", out value);
            Assert.IsFalse(keyFound);
            Assert.AreEqual(0, value);


            keyFound = map.TryGetValue("bar", out value);
            Assert.IsTrue(keyFound);
            Assert.AreEqual(20, value);

            Assert.AreEqual(2, map.Count);

            var map2 = new Dictionary<string, int>()
            {
                {"abc", 1 },
                {"xyz", 2 }
            };



        }

        [Test]
        public void Generics()
        {
            Fred<string> fred1 = new Fred<string>("ABC");
            Assert.AreEqual("ABC", fred1.Foo());


            Fred<int> fred2 = new Fred<int>(10);
            Assert.AreEqual(10, fred2.Foo());

        }

        [Test]
        public void VarKeyword()
        {
            var fred1 = new Fred<string>("ABC");
            Assert.AreEqual("ABC", fred1.Foo());


            var fred2 = new Fred<int>(10);
            Assert.AreEqual(10, fred2.Foo());

        }

        [Test]
        public void EnumerateTheElements()
        {
            int[] arr1 = { 10, 11, 12, 13 };                // Define the array.

            foreach (int item in arr1)                      // Enumerate the elements.
                Console.WriteLine($"Item value: {item}");
        }

        [Test]
        public void UsingIEnumerableAndIEnumerator()
        {
            Spectrum spectrum = new Spectrum();
            foreach (string color in spectrum)
                Console.WriteLine(color);
        }

        [Test]
        public void UsingAnIteratorToCreateAnEnumerator()
        {
            MyClassEnumerator mc = new MyClassEnumerator();

            foreach (string shade in mc)
                Console.WriteLine(shade);
        }

        [Test]
        public void UsingAnIteratorToCreateAnEnumerable()
        {
            MyClassEnumerable mc = new MyClassEnumerable();

            foreach (string shade in mc)
                Console.Write($"{shade} ");

            foreach (string shade in mc.BlackAndWhite())
                Console.Write($"{shade} ");
        }

        [Test]
        public void ProducingMultipleEnumerables()
        {
            Spectrum spectrum = new Spectrum();

            foreach (string color in spectrum.UVtoIR())
                Console.Write($"{color} ");
            Console.WriteLine();

            foreach (string color in spectrum.IRtoUV())
                Console.Write($"{color} ");
            Console.WriteLine();
        }

        [Test]
        public void IteratorsAsProperties()
        {

        }
    }
}
