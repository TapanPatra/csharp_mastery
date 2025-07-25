using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Structs
{
    public struct Point
    {
        public int m_x;
        public int m_y;

        public Point(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public override string ToString()
        {
            return String.Format("X is {0} and Y is {1}", m_x, m_y);
        }

    }

    public class PointHolder
    {
        public Point Current;
        public PointHolder(Point point)
        {
            Current = point;
        }
    }



    [TestFixture]
    public class PointTest
    {
        [Test]
        public void PrintPoints()
        {
            Point start = new Point(5, 5);
            Console.WriteLine("Start: {0}", start);
        }

        [Test]
        public void BoxingAndUnboxingAValueType()
        {
            int v = 123;
            object o = v; // Boxing
            Console.WriteLine($"UnBoxing: {v}");
            Console.WriteLine($"{o}");

            int value = 15;
            DateTime dt = DateTime.Now;
            Console.WriteLine("Value: {0}, date: {1}", value, dt);
        }
        [Test]
        public void CallingStructWithoutNew()
        {
            Point[] points = new Point[2];
            Console.WriteLine("[1] : {0}", points[1]);
        }
        [Test]
        public void MutableStruct()
        {
            Point point = new Point(10, 15);

            PointHolder pointHolder = new PointHolder(point);
            Console.WriteLine(pointHolder.Current);

            Point current = pointHolder.Current;
            current.m_x = 30;
            Console.WriteLine(pointHolder.Current);

        }

        [Test]
        public void ImMutableClassTest()
        {
            string s = "Hello There";
            string s2 = s;
            s = s.Replace("Hello", "Good Bye");
            Console.WriteLine(s2);
            s2 = s;
            Console.WriteLine(s);
            Console.WriteLine(s2);
        }


    }


}
