using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fundamentals
{
    public delegate void GenericAction<T>(T value);

    [TestFixture]
    public class AnnonymousFunctionTest
    {
        private void MethodTakingString(string value)
        {
            Console.WriteLine(value);

        }

        private double SqaurRoot(int value)
        {
            return Math.Sqrt(value);
        }

        [Test]
        public void MethodGroupConversion()
        {
            GenericAction<string> action = MethodTakingString;
            action("Hi!");         
        }

        [Test]
        public void ListConversion()
        {
            List<int> orginal = new List<int> { 1, 2, 3 };
            List<double> squareroots = orginal.ConvertAll(SqaurRoot);
            foreach(double item in squareroots)
            {
                Console.WriteLine(item);
            }

        }

        [Test]
        public void AnnonymousMethod()
        {
            Converter<int, double> converter = delegate (int x)
            {
                return Math.Sqrt(x);
            };

            List<int> orginal = new List<int> { 1, 2, 3 };
            List<double> squareroots = orginal.ConvertAll(converter);
            foreach (double item in squareroots)
            {
                Console.WriteLine(item);
            }

        }

        [Test]
        public void AnnonymousMethod2()
        {
            List<int> orginal = new List<int> { 1, 2, 3 };
            List<double> squareroots = orginal.ConvertAll(delegate (int x)
            {
                return Math.Sqrt(x);
            });
            foreach (double item in squareroots)
            {
                Console.WriteLine(item);
            }
        }

        [Test]
        public void ClosureAnnonymousMethod()
        {
            int calls = 0;
            double power = 0.5;

            Converter<int, double> converter = delegate (int x)
            {
                calls++;
                return Math.Pow(x, power);
            };


            List<int> orginal = new List<int> { 1, 2, 3 };
            List<double> squareroots = orginal.ConvertAll(converter);
            foreach (double item in squareroots)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Toatal calls : {0}", calls);

            power = 2;
            List<double> squares = orginal.ConvertAll(converter);
            foreach (double item in squares)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Toatal calls : {0}", calls);

        }

        [Test]
        public void ClosureLambda()
        {
                double power = 0.5;

                Converter<int, double> convertr = (int x) =>
                {
                   
                    return Math.Pow(x, power);
                };

                
                List<int> orginal = new List<int> { 1, 2, 3 };
                List<double> squareroots = orginal.ConvertAll(convertr);
                foreach (double item in squareroots)
                {
                    Console.WriteLine(item);
                }

         }

        [Test]
        public void LamdaShortHand()
        {
            double power = 0.5;

            Converter<int, double> converter = x => Math.Pow(x, power);
            Console.WriteLine(converter);
            List<int> orginal = new List<int> { 1, 2, 3 };
            List<double> squareroots = orginal.ConvertAll(converter);
            foreach (double item in squareroots)
            {
                Console.WriteLine(item);
            }
        }

        [Test]
        public void ExpressionTrees()
        {
            Expression<Converter<int, double>> converter = x => Math.Pow(x, 0.5);
            Console.WriteLine(converter);

            Converter<int, double> compiled = converter.Compile();
            Console.WriteLine(compiled.Invoke(5));
        }

        [Test]
        public void IgnoreParametersInAnnonymousMethod()
        {
            Converter<int, double> converter = delegate { return 5.5; };

            Console.WriteLine(converter(10));
        }
        [Test]
        public void GenericDelegate()
        {
           // Action<int> x1 = null;
            //Action<int, int, string> x2= null;


           // Func<int> x3 = null;
            Func<int, int, string> x4 = Foo;
        }

        private string Foo(int x, int y)
        {
            return x.ToString() + y.ToString();
        }

        [Test]
        public void DangerWithDelegateCapturedVariable1()
        {
            List<string> words = new List<string> { "Tapan", "Kumar", "Patra" };
            List<Action> actions = new List<Action>();
            
            foreach(string word in words)
            {
                actions.Add(() => Console.WriteLine(word));
            }

            foreach(Action action in actions)
            {
                action();
            }

        }

        [Test]
        public void DangerWithDelegateCapturedVariable2()
        {
            List<string> words = new List<string> { "Tapan", "Kumar", "Patra" };
            List<Action> actions = new List<Action>();

            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                actions.Add(() => Console.WriteLine("{0} : {1}", i, word));
            }

            foreach (Action action in actions)
            {
                action();
            }

        }



    }

}
