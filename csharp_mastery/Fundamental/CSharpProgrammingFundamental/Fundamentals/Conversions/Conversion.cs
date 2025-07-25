using CSharpFundamentals.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._03_Fundamentals.Conversions
{
    [TestFixture]
    public class Conversion
    {
        class Person
        {
            public string Name= "Anonymous";
            public int Age =25;

            public Person()
            {

            }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public static implicit operator int(Person p) // Convert Person to int.
            {
                return p.Age;
            }

            public static implicit operator Person(int i) // Convert int to Person.
            {
                return new Person("Nemo", i); // ("Nemo" is Latin for "No one".)
            }
        }

        class Employee : Person
        {
            public Employee()
            {

            }

            public Employee(string name, int age) : base(name, age)
            {
            }
        }


        [Test]
        public void CheckedUncheckedOperator()
        {
            ushort sh = 2000;
            byte sb;

            checked
            {
                unchecked
                {
                    sb = (byte)sh;
                    Console.WriteLine($"sb: {sb}");
                }

                sb = checked((byte)sh);
                Console.WriteLine($"sb: {sb}");
            }


            sb = unchecked((byte)sh);             // Most significant bits lost
            Console.WriteLine($"sb: {sb}");

            sb = checked((byte)sh);               // OverflowException raised
            Console.WriteLine($"sb: {sb}");


        }

        [Test]
        public void Boxing()
        {
            int i = 10; // Create and initialize value type

            object oi = i; // Create and initialize reference type
            Console.WriteLine($"i: {i}, io: {oi}");

            i = 12;
            oi = 15;
            Console.WriteLine($"i: {i}, io: {oi}");
        }

        [Test]
        public void UnBoxing()
        {
            int i = 10;
            object oi = i;

            int j = (int)oi;
            Console.WriteLine($"i: {i},  oi: {oi},  j: {j}");
        }

        [Test]
        public void UserDefinedConversion()
        {
            Person bill = new Person("bill", 25);

            int age = bill;
            Console.WriteLine($"Person Info: {bill.Name}, {age}");

            Person anon = 35;
            Console.WriteLine($"Person Info: {anon.Name}, {anon.Age}");


            Employee william = new Employee("William", 25);
            float fVar = bill;
            Console.WriteLine($"Person Info: {bill.Name}, {fVar}");


        }

        [Test]
        public void AsOperator()
        {
            Employee bill = new Employee();
            Person p;
            p = bill as Person;
            if (p != null)
            {
                Console.WriteLine($"Person Info: {p.Name}, {p.Age}");
            }
        }

        [Test]
        public void IsOperator()
        {
            Employee bill = new Employee();
            // Check if variable bill can be converted to type Person
            if (bill is Person)
            {
                Person p = bill;
                Console.WriteLine($"Person Info: {p.Name}, {p.Age}");
            }
        }
    }
}
