using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.GettingStarted
{
    internal class HelloWorld
    {
        public static void MyMain()
        {
            Console.WriteLine("Hello World");
        }
    }

    /// <summary>
    /// This class does...
    /// </summary>
    public class HelloWorldTests
    {

        [Test]
        public void MyFirstTest()
        {
            HelloWorld.MyMain();
            Assert.Pass();
        }

        [Test]
        public void TheFormatStringTest()
        {
            int var1 = 5;
            System.Console.WriteLine("The value of var1 is {0}", var1);
        }

        [Test]
        public void FormattingNumericStringsTest()
        {
            Console.WriteLine("The value: {0}.", 500); // Print out number
            Console.WriteLine("The value: {0:C}.", 500);// Format as currency

            
        }

        [Test]
        public void TheAlignmentSpecifierTest()
        {
            int myInt = 500;
            Console.WriteLine("|{0, 10}|", myInt); // Aligned right
            Console.WriteLine("|{0,-10}|", myInt); // Aligned left

            
        }

        [Test]
        public void TheFormatFieldTest()
        {
            double myDouble = 12.345678;
            Console.WriteLine("{0,-10:G}", myDouble);//General", myDouble);
            Console.WriteLine("{0,-10}", myDouble); //Default, same as General", myDouble);
            Console.WriteLine("{0,-10:F4}", myDouble);// Fixed Point, 4 dec places", myDouble);
            Console.WriteLine("{0,-10:C}", myDouble);//Currency", myDouble);
            Console.WriteLine("{0,-10:E3}", myDouble);//Sci. Notation, 3 dec places", myDouble);
            Console.WriteLine("{0,-10:x}", 1194719);//Hexadecimal integer", 1194719);
        }

        [Test]
        public void StringInterpolationTest()
        {
            int latitude = 43;
            int longitude = 11;
            string north = "N";
            string south = "S";
            string east = "E";
            Console.WriteLine($"The city of Florence, Italy is located at latitude {latitude}{north} and longitude { longitude}{ east}. By comparison, the city of Djibouti(in the country of Djibouti) is located at latitude { longitude}{ north} and longitude { latitude}{ east}. The city of Moroni in the Comoros Islands is located at latitude { longitude}{ south}andlongitude { latitude}{ east}.");

            int myInt = 500;
            Console.WriteLine($"The value: {myInt}.");
            Console.WriteLine($"The value: {myInt:C}.");
        }

        public void MultipleMarkersAndValuesTest()
        {
 
            Console.WriteLine("Three integers are {1}, {0} and {1}.", 3, 6);

            Console.WriteLine("Two integers are {0} and {2}.", 3, 6); // Error!
        }
    }
    
}
