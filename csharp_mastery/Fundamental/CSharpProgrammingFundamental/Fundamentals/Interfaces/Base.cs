using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{

    public interface IHelper
    {
        void HelpMeNow();
    }

    public class Base : IHelper
    {
         void IHelper.HelpMeNow()
        {
            Console.WriteLine("Base.HelpMeNow");
        }
    }

    public class Derived : Base
    {
        public void HelpMeNow()
        {
            Console.WriteLine("Derived.HelpMeNow");
        }
    }

    [TestFixture]
    public class DerivedTest
    {
        [Test]
        public void InterfaceInheritance()
        {
            Derived der = new Derived();
            der.HelpMeNow();

            IHelper helper = (IHelper)der;
            helper.HelpMeNow();

        }
    }

}
