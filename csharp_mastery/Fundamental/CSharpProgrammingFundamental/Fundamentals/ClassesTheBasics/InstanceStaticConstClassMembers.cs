using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    class D
    {
        public int Mem1;
        public static int Mem2;
        public const double PI = 3.1416;

        public void SetVars(int v1, int v2) // Set the values
        { 
            Mem1 = v1; 
            Mem2 = v2; 
        }
        public void Display(string str)
        { 
            Console.WriteLine("{0}: Mem1= {1}, Mem2= {2}", str, Mem1, Mem2); 
        }

        static public int A; // Static field
        static public void PrintValA() // Static method
        {
            Console.WriteLine("Value of A: {0}", A);
        }
    }


    internal class InstanceStaticConstClassMembers
    {
        [Test]
        public void InstanceClassMembersTest()
        {
            D d1 = new D(), d2 = new D(); // Create two instances.
            d1.SetVars(2, 4); // Set d1's values.
            d1.Display("d1");
           
        }

        [Test]
        public void StaticClassMembersTest()
        {
            D d1 = new D(), d2 = new D(); // Create two instances.
            d1.SetVars(2, 4); // Set d1's values.
            d1.Display("d1");
            d2.SetVars(15, 17); // Set d2's values.
            d2.Display("d2");
            d1.Display("d1"); // Display d1 again and notice that the
                              // value of static member Mem2 has changed!
        }

        [Test]
        public void  StaticFunctionMembersTest()
        {
            D.A = 10; // Use dot-syntax notation
            D.PrintValA();
        }
        [Test]
        public void MemberConstantsTest()
        {
            Console.WriteLine($"pi = {D.PI}"); // Use the const field PI
        }
    }
}
