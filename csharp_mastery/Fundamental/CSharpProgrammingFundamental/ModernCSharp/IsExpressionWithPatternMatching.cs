using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._04_ModernCSharp
{
    public class Shape { }

    public class Square : Shape 
    {
        public int Size;
    }

    public class Circle : Shape
    {
        public int Radius;
    }

    public static class AreaCalculator
    {
        public static double CalculateArea(Shape shape)
        {
            if (shape is Square square) return square.Size * square.Size;

            if (shape is Circle circle) return 2 * 2.314 * circle.Radius;

            throw new InvalidOperationException("Not a valid Shape");
        }
    }

    [TestFixture]
    public class IsExpressionWithPatternMatching
    {
        [Test]
        public void CalculateArea()
        {
            var square = new Square { Size = 10 };
            var circle = new Circle { Radius = 10 };

            Console.WriteLine($"Area of Square is {AreaCalculator.CalculateArea(square)}");

            Console.WriteLine($"Area of Circle is {AreaCalculator.CalculateArea(circle)}");

        }
    }
}
