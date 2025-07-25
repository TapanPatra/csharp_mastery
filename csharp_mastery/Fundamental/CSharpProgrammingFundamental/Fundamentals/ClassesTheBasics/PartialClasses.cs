using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    public partial class PersonPartialClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        partial void LogInfo(string message);

        
    }

    public partial class PersonPartialClass
    {
        public int Age { get; set; }
        public string Address { get; set; }

        partial void LogInfo(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
        public void LogMessageInfo(string v)
        {
            LogInfo(v);
        }
    }

    [TestFixture]
    public class PartialClassesTest
    {
        [Test]
        public void TestFullName()
        {
            var person = new PersonPartialClass();
            person.FirstName = "John";
            person.LastName = "Doe";

            Assert.AreEqual("John Doe", person.FirstName + " " + person.LastName);
        }

        [Test]
        public void TestAgeAndAddress()
        {
            var person = new PersonPartialClass();
            person.Age = 30;
            person.Address = "123 Main St";

            Assert.AreEqual(30, person.Age);
            Assert.AreEqual("123 Main St", person.Address);
        }

        [Test]
        public void PartialMethodExample()
        {
            var person = new PersonPartialClass();
            person.LogMessageInfo("my message");

        }
    }
}
