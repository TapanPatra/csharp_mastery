using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    class ShapeClass
    {
        readonly double PI = 3.1416;
        public readonly int NumberOfSides;

        public ShapeClass(double side1, double side2) // Constructor
        {
            // Shape is a rectangle
            NumberOfSides = 4;

        }
        public ShapeClass(double side1, double side2, double side3)
        { // Constructor
          // Shape is a triangle
            NumberOfSides = 3;
        }

    }
   

    [TestFixture]
    public class ReadonlyModifier
    {
        [Test]
        public void ReadonlyModifierTest()
        {
            var trainagle = new ShapeClass(10, 20, 31);
            Console.WriteLine("Number of sides {0}", trainagle.NumberOfSides);
        }
    }
}
