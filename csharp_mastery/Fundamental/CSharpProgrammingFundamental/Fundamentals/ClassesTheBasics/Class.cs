using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{
    public class Greeter
    {
        private readonly string speaker;

        public Greeter(string speaker)
        {
            this.speaker = speaker;

        }

        public string Speaker
        {
            get
            {
                Console.WriteLine("Returing Speaker is = " + speaker);
                return speaker;
            }
        }


        public string SayHello(string recipient)
        {
            if (recipient == null)
            {
                throw new ArgumentNullException("recipient");
            }
            if(Speaker == null)
            {
                return "Hello " + recipient;
            }
            return "Hello " + recipient + " from " + speaker;
        }
    }

    [TestFixture]
    public class GreeterTest
    {
        [Test]
        public void SayHello_ReturnsHelloWithRecipientName()
        {
            Greeter greeter = new Greeter("Rob");
            string greeting = greeter.SayHello("Jon");
            Assert.AreEqual("Hello Jon from Rob", greeting);
        }

        [Test]
        public void CanConstructGreeterWithoutSpeakerName()
        {
            new Greeter(null);
        }

        [Test]
        public void SayHello_ReturnsHelloWithoutRecipientName()
        {
            Greeter greeter = new Greeter(null);
            string greeting = greeter.SayHello("Jon");
            Assert.AreEqual("Hello Jon", greeting);
        }
        [Test]
        public void SayHello_ReturnsArgumentNullException()
        {
            Greeter greeter = new Greeter("Rob");
            Assert.Throws<ArgumentNullException>(() => greeter.SayHello(null));

        }

        [Test]
        public void SpeakerProperty_IsSetFromConstructor()
        {
            Greeter greeter = new Greeter("Rob");
            Assert.AreEqual("Rob", greeter.Speaker);
            Assert.AreNotEqual("rob", greeter.Speaker);
        }

    }

    public class Person
    {
        public string Name;

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I am {1}", to, Name);
        }

        public static Person Parse(string str)
        {
            var person = new Person();
            person.Name = str;

            return person;
        }
    }

    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void IntroduceTest()
        {
            var person = Person.Parse("John");
            person.Introduce("Mosh");
        }
    }
}
