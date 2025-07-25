using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Interfaces
{
    public interface IInfc
    {
        void PrintOut(string description);
    }

    public class MyClass : IInfc
    {
       public void PrintOut(string description)
        {
            Console.WriteLine("Calling through {0}", description);
        }
    }

    [TestFixture]
    public class ExampleInterfaceTest
    {
        [Test]
        public void CallingInterfaceMethodTest()
        {
            var myClass = new MyClass();
            myClass.PrintOut("object"); // Call class object implementation method.

            var  iInfc= (IInfc)myClass; // Cast class object ref to interface ref.
            iInfc.PrintOut("interface"); // Call interface method.
            

        }

        [Test]
        public void AsOperatorTest()
        {
            var myClass = new MyClass();

            var iInfc = myClass as IInfc;
            if(iInfc != null)
            {
                iInfc.PrintOut("interface as operator");
            }
        }
    }
}
