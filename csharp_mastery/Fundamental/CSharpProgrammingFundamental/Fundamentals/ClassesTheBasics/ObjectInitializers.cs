using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    public class PointClass
    {
        public int X = 1;
        public int Y = 2;
    }

    [TestFixture]
    public class ObjectInitializers
    {
        [Test]
        public void ObjectInitializersTest()
        {
            PointClass pt1 = new PointClass();
            PointClass pt2 = new PointClass { X = 5, Y = 6 };
            Console.WriteLine("pt1: {0}, {1}", pt1.X, pt1.Y);
            Console.WriteLine($"pt2: {pt2.X}, {pt2.Y}");
        }
    }
}
