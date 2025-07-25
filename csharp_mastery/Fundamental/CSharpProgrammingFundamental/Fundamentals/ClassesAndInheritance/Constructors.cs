using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    public class Vehicle
    {
        private readonly string _registrationNumber;
        public string Brand { get; set; }
        public int Year { get; set; }

        // Static constructor
        static Vehicle()
        {
            Console.WriteLine("Static constructor of Vehicle called");
        }

        // Default constructor
        public Vehicle()
        {
            Brand = "Unknown";
            Year = DateTime.Now.Year;
        }

        public Vehicle(string registrationNumber)
        {
            _registrationNumber = registrationNumber;

            Console.WriteLine("Vehicle is being initialized. {0}", registrationNumber);
        }

        public Vehicle(string registrationNumber, string brand, int year)
        {
            _registrationNumber = registrationNumber;
            Brand = brand;
            Year = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Year: {Year}");
        }
    }

    public class Car : Vehicle
    {
        public string Model { get; set; }

        // Static constructor
        static Car()
        {
            Console.WriteLine("Static constructor of Car called");
        }

        // Default constructor
        public Car()
        {
            Model = "Unknown Model";
        }


        public Car(string registrationNumber)
            : base(registrationNumber)
        {
            Console.WriteLine("Car is being initialized. {0}", registrationNumber);
        }

        

        public Car(string registrationNumber, string brand, int year, string model) : base(registrationNumber, brand, year)
        {
            Model = model;
        }

        public void DisplayCarInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Year: {Year}, Model: {Model}");
        }
    }


    [TestFixture]
    public class ConstructorsTest
    {
        [Test]
        public void CarConstructorTest()
        {
            var car = new Car("XYZ1234");
        }

        [Test]
        public void ConstructorsWithParametersTest()
        {
            Vehicle vehicle = new Vehicle("1234", "Generic Brand", 2020);
            vehicle.DisplayInfo();

            Car car = new Car("6789", "Toyota", 2022, "Camry");
            car.DisplayCarInfo();
        }

        [Test]
        public void DefaultConstructorsTest()
        {
            Vehicle vehicle1 = new Vehicle();
            vehicle1.DisplayInfo();

            Car car1 = new Car();
            car1.DisplayCarInfo();
        }

        [Test]
        public void StaticConstructorTest()
        {
            Vehicle vehicle1 = new Vehicle();
            vehicle1.DisplayInfo();

            Vehicle vehicle2 = new Vehicle("1234", "Generic Brand", 2020);
            vehicle2.DisplayInfo();

            Car car1 = new Car();
            car1.DisplayCarInfo();

            Car car2 = new Car("5678", "Toyota", 2022, "Camry");
            car2.DisplayCarInfo();
        }
    }
}
