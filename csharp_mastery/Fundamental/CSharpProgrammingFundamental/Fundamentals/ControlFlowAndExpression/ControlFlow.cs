using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFundamental._03_Fundamentals.Methods;
using CSharpFundamental._04_ModernCSharp;
using NUnit.Framework;

namespace Fundamentals.Tests
{
    public abstract class Shape { }

    public class Square : Shape
    {
        public double Side { get; set; }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
    }

    public class Triangle : Shape
    {
        public double Height { get; set; }
    }
    [TestFixture]
    public class ControlFlow
    {

        [Test]
        public void IfElse()
        {

	        int i = 10, j = 20;
	
	        if (i > j)
	        {
	            Console.WriteLine("i is greater than j");
	        }
	
	        if (i < j)
	        {
	             Console.WriteLine("i is less than j");
	        }        
	
	        if (i == j)
	        {
	            Console.WriteLine("i is equal to j");
	        }   

        }

        [Test]
        public void ElseIf()
        {
	         int i = 10, j = 20;

             if (i > j)
    	     {
        	    Console.WriteLine("i is greater than j");
   	 	     }
             else if (i < j)
    	     {
                Console.WriteLine("i is less than j");
    	     }
             else
    	     {
                Console.WriteLine("i is equal to j");
    	     }
        }

        [Test]
        public void SwitchWithPatternExpressions()
        {
            var shapes = new List<Shape>();

            shapes.Add(new Circle() { Radius = 7 });
            shapes.Add(new Square() { Side = 5 });
            shapes.Add(new Triangle() { Height = 4 });
            var nullSquare = (Square)null;
            shapes.Add(nullSquare);

            foreach (var shape in shapes)
            {
                switch (shape)                //Evaluate the type and/or value of variable shape.
                {
                    case Circle circle:        //Equivalent to if(shape is Circle)
                        Console.WriteLine($"This shape is a circle of radius {circle.Radius}");
                        break;

                    case Square square when square.Side > 10: //Matches only a subset of Squares
                        Console.WriteLine($"This shape is a large square of side {square.Side}");
                        break;

                    case Square square:
                        Console.WriteLine($"This shape is a square of side {square.Side}");
                        break;

                    case Triangle triangle:    // Equivalent to if(shape is Triangle)
                        Console.WriteLine($"This shape is a triangle of side {triangle.Height}");
                        break;

                    // case Triangle triangle when triangle.Height < 5: //Compile error
                    // Console.WriteLine($"This shape is a triangle of side { triangle.Height }");
                    //break;

                    case null:
                        Console.WriteLine($"This shape could be a Square, Circle or a Triangle");
                        break;

                    default:
                        throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
                }
            }
        }


        [Test]
        public void Switch()
        {
	        int x = 10;

	        switch (x)
	        { 
	            case 5:
	            Console.WriteLine("Value of x is 5");
	            break;
	            case 10:
	            Console.WriteLine("Value of x is 10");
	            break;
	            case 15:
	            Console.WriteLine("Value of x is 15");
	            break;
	            default:
	            Console.WriteLine("Unknown value");
	            break;
	        }
        }

        [Test]
        public void ForLoop()
        {
	        for (int i = 0; i < 10; i++)
	        {
    	        Console.WriteLine("Value of i: {0}", i);
	        }
        }

        [Test]
        public void BreakInFor()
        {
	        for (int i = 0; i < 10; i++)
	        {
	            if( i == 5 )
	                break;
	
	            Console.WriteLine("Value of i: {0}", i);
	        }
        }

        [Test]
        public void While()
        {
	        int i = 0;
	
	        while (i < 10)
	        {
	            Console.WriteLine("Value of i: {0}", i);
	
	            i++;
	        }
        }

        [Test]
        public void BreakInWhile()
        {
	        int i = 0;
	
	        while (true)
	        {
	            Console.WriteLine("Value of i: {0}", i);
	
	            i++;
	
	            if (i > 10)
	                break;
	        }
        }

        [Test]
        public void DoWhile()
        {
	        int i = 0;
	
	        do
	        {
	            Console.WriteLine("Value of i: {0}", i);
	    
	            i++;
	
	        } while (i < 10);

        }
        [Test]
        public void Return()
        {
            Assert.AreEqual(12, MethodReturnInt32());
        }

        public int MethodReturnInt32()
        {
            return 12;
        }



        [Test]
        public void ContinueInWhile()
        {
            int x = 5;

            while(x < 10)
            {
                if(x%7 != 0)
                {
                    continue;
                }
                else
                {
                    break;
                }

            }

        }

        [Test]
        public void NestedForLoop()
        {
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<5; j++)
                {
                    if( i+ j == 4)
                    {
                        break;
                    }

                    Console.WriteLine("i : {0} and j :{1}", i, j);
                }
            }

        }

        [Test]
        public void ForEach()
        {
            List<string> names = new List<string>() { "Tapan", "Halikul", "Ammiraju" };

            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

        }

        [Test]
        public void UsingStatement()
        {
            // using statement
            using (TextWriter tw = File.CreateText("Lincoln.txt"))
            {
                tw.WriteLine("Four score and seven years ago, ...");
            }

            // using statement
            using (TextReader tr = File.OpenText("Lincoln.txt"))
            {
                string InputString;
                while (null != (InputString = tr.ReadLine()))
                    Console.WriteLine(InputString);
            }
        }

    }
}
