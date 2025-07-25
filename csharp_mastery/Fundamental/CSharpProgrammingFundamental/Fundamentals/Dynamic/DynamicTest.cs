using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.DataTypes
{
    [TestFixture]
    public class DynamicTest
    {
        [Test]
        public void FirstDynamicTest()
        {
            dynamic text = "hello";
            int length = text.Length;
            Assert.AreEqual(5, length);

            //reflection
            PropertyInfo lengthProperty = text.GetType().GetProperty("Length");
            int lengthPropertyValue = lengthProperty.GetValue(text, null);

            Assert.AreEqual(5, lengthPropertyValue);
        }


        [Test]
        public void SecondDynamicTest()
        {
            dynamic text = "hello";
            int result = CallMe(text);
            Assert.That(result, Is.EqualTo(2));

        }
        public int CallMe(object x)
        {
            return 1;
        }

        public int CallMe(string x)
        {
            return 2;
        }

        public Type CallMe<T>(IEnumerable<T> sequence)
        {
            return typeof(T);
        }

        [Test]
        public void ThirdDynamicTest()
        {
            dynamic ints = new List<int>();
            Type result = CallMe(ints);

            Assert.That(typeof(int), Is.EqualTo(result));
        }
        [Test]
        public void ExpandoObjectTest()
        {
            dynamic expando = new ExpandoObject();

            IDictionary<string, object> dictionary = expando;

            expando.Age = 35;
            dictionary["Name"] = "Tapan";

            Assert.AreEqual("Tapan", expando.Name);
            Assert.That(dictionary["Age"], Is.EqualTo(35));


            Action greeting = () => Console.WriteLine("Hello") ;
            dictionary["Greeting"] = greeting;

            expando.Greeting();

            Func<int, int> doubleMe = x => x * 2;
            dictionary["doubler"] = doubleMe;
            int doubled = expando.doubler(10);
            Assert.That(doubled, Is.EqualTo(20));

            dynamic doubler2 = expando.doubler;
            doubler2.Invoke(10);
            Assert.That(doubled, Is.EqualTo(20));

        }

        [Test]
        public void SecondExpandoObjectTest()
        {
            dynamic propoties = GetPropoties();
            int Age = propoties.Age;
            string Name = propoties.Name;

            //Assert.AreEqual(Age, 35);
            //Assert.AreEqual(Name, "Jon");

        }

        public dynamic GetPropoties()
        {
            Dictionary<string, object> propoties = new Dictionary<string, object>()
            {
                { "Name", "Jon" },
                {"Age", 35 },
                {"Town", "Reading" }
            };

            IDictionary<string, object> expando = new ExpandoObject();

            foreach( var pair in propoties )
            {
                expando[pair.Key] = pair.Key;
            }
            
            return expando;

        }

    }
}
