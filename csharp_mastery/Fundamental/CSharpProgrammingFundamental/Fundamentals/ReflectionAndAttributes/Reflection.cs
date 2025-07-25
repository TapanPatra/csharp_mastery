using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CSharpFundamental._03_Fundamentals.ReflectionAndAttributes
{
    [TestFixture]
    public class Reflection
    {
        class BaseClass
        {
            public int BaseField = 0;
        }

        class DerivedClass : BaseClass
        {
            public int DerivedField = 0;
        }


        [Test]
        public void GetType()
        {
            var bc = new BaseClass();
            var dc = new DerivedClass();

            BaseClass[] bca = new BaseClass[] { bc, dc };

            foreach (var v in bca)
            {
                Type t = v.GetType();                     // Get the type.

                Console.WriteLine($"Object type : {t.Name}");

                FieldInfo[] fi = t.GetFields();           // Get the field information.
                foreach (var f in fi)
                    Console.WriteLine($"      Field : {f.Name}");
                Console.WriteLine();
            }
        }

        [Test]
        public void Typeof()
        {
            Type tbc = typeof(DerivedClass); // Get the type.
            Console.WriteLine($"Object type : {tbc.Name}");

            FieldInfo[] fi = tbc.GetFields();
            foreach (var f in fi)
                Console.WriteLine($"      Field : {f.Name}");
        }



    }
}
