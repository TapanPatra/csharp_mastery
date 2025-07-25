using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    public class PersonClass 
    {
        public string Name { get; private set; }
        public PersonClass(string name) { Name = name; }
    }

    [TestFixture]
    public class AccessModifiersOnAccessors
    {
        [Test]
        public void AccessModifiersOnAccessorsTest()
        {
            PersonClass p = new PersonClass("Capt. Ernest Evans");
            Console.WriteLine($"Person's name is {p.Name}");
        }
    }
}
