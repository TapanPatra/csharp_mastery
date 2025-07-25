using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    public class Person
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static int TotalPersonsCreated { get; private set; }

        public Person()
        {
            Birthdate = DateTime.Now;
            TotalPersonsCreated++;
        }


        public Person(DateTime birthdate)
        {
            Birthdate = birthdate;
            TotalPersonsCreated++;
        }


        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;

                return years;
            }
        }
    }

    public class RightTriangle
    {
        public double A = 3;
        public double B = 4;
        public double Hypotenuse // Read-only property
        {
            get { return Math.Sqrt((A * A) + (B * B)); } // Calculate return value
        }
    }


    [TestFixture]
    class Program
    {
        [Test]
        public void PropotiesTest()
        {
            var person = new Person(new DateTime(1982, 1, 1));
            Console.WriteLine(person.Age);
        }
        [Test]
        public void ReadOnlyPropertyTest()
        {
            RightTriangle c = new RightTriangle();
            Console.WriteLine($"Hypotenuse: {c.Hypotenuse}");
        }

        [Test]
        public void AutopropertiesTest()
        {
            Person person = new Person(new DateTime(1982, 1, 1));
            person.Name = "John";

            Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Age: {person.Age}");
        }

        [Test]
        public void StaticPropertiesTest()
        {
            Person person1 = new Person();
            person1.FirstName = "John";
            person1.LastName = "Doe";

            Person person2 = new Person();
            person2.FirstName = "Jane";
            person2.LastName = "Smith";

            Console.WriteLine($"Name: {person1.FirstName} {person1.LastName}, Age: {person1.Age}");
            Console.WriteLine($"Name: {person2.FirstName} {person2.LastName}, Age: {person2.Age}");

            Console.WriteLine($"Total Persons Created: {Person.TotalPersonsCreated}");
        }


    }
}
