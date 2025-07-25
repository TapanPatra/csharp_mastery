using CSharpFundamental._02_DataTypes.ClassesTheBasics;
using CSharpFundamental._03_Fundamentals.Testability;
using CSharpFundamentals.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesAndInheritance
{
    class BaseClass // Base class
    {
        public string Field1 = "BaseClass Field1";

        private int _myInt = 5;
        virtual public int MyProperty
        {
            get { return _myInt; }
        }


        public void Method1(string value)
        {
            Console.WriteLine($"BaseClass.Method1: {value}");
        }

        public void Print()
        {
            Console.WriteLine("This is the base class.");
        }

        virtual public void PrintToConsole()
        {
            Console.WriteLine("This is the base class.");
        }

        virtual public void PrintInfo()
        {
            Console.WriteLine("This is the base class.");
        }

    }

    class DerivedClass : BaseClass // Derived class
    {
        new public string Field1 = "DerivedClass Field1";    // Mask the base member.

        private int _myInt = 10;
        override public int MyProperty
        {
            get { return _myInt; }
        }


        new public void Method1(string value)
        {
            Console.WriteLine($"DerivedClass.Method1: {value}");
        }
        public string Field2 = "Derived class field";

        public void Method2(string value)
        {
            Console.WriteLine($"Derived class -- Method2: {value}");
        }

        public void PrintField1()
        {
            Console.WriteLine(Field1);                       // Access the derived class.
            Console.WriteLine(base.Field1);                  // Access the base class.
        }

        new public void Print()
        {
            Console.WriteLine("This is the derived class.");
        }

        override public void PrintToConsole()
        {
            Console.WriteLine("This is the derived class.");
        }

        override public void PrintInfo()
        {
            Console.WriteLine("This is the derived class.");
        }
    }

    class SecondDerived : DerivedClass
    {
        override public void PrintToConsole()
        {
            Console.WriteLine("This is the second derived class.");
        }

        new public void PrintInfo()
        {
            Console.WriteLine("This is the second derived class.");
        }
    }

    [TestFixture]
    public class ClassesAndInheritance
    {
        [Test]
        public void AccessingTheInheritedMembersTest()
        {
            DerivedClass dc = new DerivedClass();
            dc.Method1(dc.Field1); // Base method with base field
            dc.Method1(dc.Field2); // Base method with derived field
            dc.Method2(dc.Field1); // Derived method with base field
            dc.Method2(dc.Field2); // Derived method with derived field
        }

        [Test]
        public void MaskingMembersOfABaseClassExample()
        {
            DerivedClass dc = new DerivedClass();// Use the masking member.
            dc.Method1(dc.Field1);// Use the masking member.
        }

        [Test]
        public void BaseClassFieldAccessExample()
        {
            DerivedClass dc = new DerivedClass();
            dc.PrintField1();
        }

        [Test]
        public void UsingReferencesToABaseClass()
        {
            DerivedClass derived = new DerivedClass();
            BaseClass mybc = (BaseClass)derived;

            derived.Print(); // Call Print from derived portion.
            mybc.Print();    // Call Print from base portion.
                             // mybc.var1 = 5; // Error: base class reference cannot
                             // access derived class members.
        }
        [Test]
        public void VirtualAndOverrideMethodsExample()
        {
            DerivedClass derived = new DerivedClass();
            BaseClass mybc = (BaseClass)derived;

            derived.PrintToConsole();
            mybc.PrintToConsole();
        }

        [Test]
        public void MultipleLevelOverrideMethodsExample()
        {
            SecondDerived derived = new SecondDerived();    // Use SecondDerived.
            BaseClass mybc = (BaseClass)derived;       // Use MyBaseClass.

            derived.PrintToConsole();
            mybc.PrintToConsole();
        }

        [Test]
        public void HiddingOverridenMethodsExample()
        {
            SecondDerived derived = new SecondDerived();          // Use SecondDerived.
            BaseClass mybc = (BaseClass)derived;        // Use MyBaseClass.

            derived.PrintInfo();
            mybc.PrintInfo();
        }

        [Test]
        public void OverridingOtherMemberTypesExample()
        {
            DerivedClass derived = new DerivedClass();
            BaseClass mybc = (BaseClass)derived;

            Console.WriteLine(derived.MyProperty);
            Console.WriteLine(mybc.MyProperty);
        }
    }
}
