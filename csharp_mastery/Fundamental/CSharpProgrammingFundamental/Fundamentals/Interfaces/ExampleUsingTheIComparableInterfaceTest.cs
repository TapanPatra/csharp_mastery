using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace CSharpFundamentals.DataTypes
{
    public struct Number : IComparable
    {
        int m_value;

        public Number(int value)
        {
            m_value = value;
        }

        public int CompareTo(object obj)
        {
            Number number2 = (Number)obj;

            if (m_value < number2.m_value)
            {
                return (-1);
            }
            else if (m_value > number2.m_value)
            {
                return (1);
            }

            else
            {
                return (0);
            }

        }

        [TestFixture]
        public class NumberTest
        {
            [Test]
            public void CompareNumber()
            {
                Number number1 = new Number(30);
                Number number2 = new Number(40);

                IComparable ic = (IComparable)number1;

                Console.WriteLine("number1 compared to number2 = {0}", ic.CompareTo(number2));
            }

            [Test]
            public void ArraySortTest()
            {
                var array = new[] { 20, 4, 16, 9, 2 };
                Array.Sort(array);

                foreach (var item in array)
                {
                    Console.WriteLine(item);

                }
            }
        }
    }
}
