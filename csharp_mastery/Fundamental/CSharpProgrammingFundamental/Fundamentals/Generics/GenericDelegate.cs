using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Generics
{
    public delegate TR Func<T1, T2, TR>(T1 p1, T2 p2); // Generic delegate


    class Simple
    {
        static public string PrintString(int p1, int p2) // Method matches delegate
        {
            int total = p1 + p2;
            return total.ToString();
        }
    }


    [TestFixture]
    public class GenericDelegate
    {
        [Test]
        public void GenericDelegateTest()
        {
            var myDel = // Create inst of delegate.
            new Func<int, int, string>(Simple.PrintString);
            Console.WriteLine($"Total: {myDel(15, 13)}"); // Call delegate.
        }
    }
}
