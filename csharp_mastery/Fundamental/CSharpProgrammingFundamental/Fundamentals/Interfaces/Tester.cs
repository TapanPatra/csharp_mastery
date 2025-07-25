using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{
    public interface IFoo
    {
        void Execute();
    }

    public interface IBar
    {
        void Execute();
    }

    public class Tester : IFoo, IBar
    {
        void IFoo.Execute()
        {
            Console.WriteLine("IFoo.Execute()");
        }

        void IBar.Execute()
        {
            Console.WriteLine("IBar.Execute()");
        }

        public void Execute()
        {
           ((IBar) this).Execute();
        }
    }

    [TestFixture]
    public class TesterTest
    {
        [Test]
        public void Test()
        {
            Tester tester = new Tester();

            tester.Execute();
            ((IFoo)tester).Execute();
            ((IBar)tester).Execute();

        }
    }

}
