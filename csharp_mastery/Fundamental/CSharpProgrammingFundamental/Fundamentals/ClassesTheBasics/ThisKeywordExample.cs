using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    class MyClass
    {
        int Var1 = 10;
        public int ReturnMaxSum(int Var1)
        {

        return Var1 > this.Var1
                        ? Var1 // Parameter
                        : this.Var1; // Field
        }
    }

    [TestFixture]
    public class ThisKeywordExample
    {
        [Test]
        public void ThisKeywordExampleTest()
        {
            MyClass mc = new MyClass();
            Console.WriteLine($"Max: {mc.ReturnMaxSum(30)}");
            Console.WriteLine($"Max: {mc.ReturnMaxSum(5)}");
        }
    }
}
