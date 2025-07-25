using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Generics
{
    interface IMyIfc<T> // Generic interface
    {
        T ReturnIt(T inValue);
    }

    class Simple<S> : IMyIfc<S> // Generic class
    {
        public S ReturnIt(S inValue) // Implement generic interface.
        { return inValue; }
    }


    [TestFixture]
    public class GenericInterfaces
    {
        [Test]
        public void GenericInterfaceTest()
        {
            var trivInt = new Simple<int>();
            var trivString = new Simple<string>();
            Console.WriteLine($"{trivInt.ReturnIt(5)}");
            Console.WriteLine($"{trivString.ReturnIt("Hi there.")}");
        }
    }
}
