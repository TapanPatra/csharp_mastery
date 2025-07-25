using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{ 
    public class DaysTemp
    {
        // Fields
        private int High = 75;
        private int Low = 45;

        // Methods
        public int GetHigh()
        {
            return High; // Access private field
        }
        public int GetLow()
        {
            return Low; // Access private field
        }

        public void SetHigh(int temp)
        {
            High = temp; // Access private field
        }
        public void SetLow(int temp)
        {
            Low =temp ; // Access private field
        }

        public float Average()
        {
            return (GetHigh() + GetLow()) / 2; // Access private methods
        }
    }

    [TestFixture]
    public class DaysTempTest
    {
        [Test]
        public void PrintLowHighAverageTempTest()
        {
            // Create two instances of DaysTemp
            DaysTemp t1 = new();
            DaysTemp t2 = new();

            // Write to the fields of each instance
            t1.SetHigh(76); t1.SetLow(57);
            t2.SetHigh(75); t2.SetLow(53);

            // Read from the fields of each instance and call a method of
            // each instance
            Console.WriteLine("t1: {0}, {1}, {2}", t1.GetHigh(), t1.GetLow(), t1.Average());
            Console.WriteLine("t2: {0}, {1}, {2}", t2.GetHigh(), t2.GetLow(), t2.Average());
        }
    }

    public class Order
    {

    }

    public class Customer
    {
        public int Id;
        public string Name;
        public readonly List<Order> Orders = new List<Order>();

        public Customer(int id)
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            // ....
        }
    }

    [TestFixture]
    public class FieldsTest
    {
        [Test]
        public void GetAndSetField()
        {
            var customer = new Customer(1);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());

            customer.Promote();

            Console.WriteLine(customer.Orders.Count);

        }
    }
}
