using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ValueTypesandReferenceTypes
{
    /// <summary> Open XML tag for the class.
    /// This is class MyClass, which does the following wonderful things, using
    /// the following algorithm. ... Besides those, it does these additional
    /// amazing things.
    /// </summary> Close XML tag.
    [TestFixture]
    public class NullableTypeTest
    {
        [Test] public void TestNullableType()
        {
            //Nullable<DateTime> date = null;

            DateTime? date = null;



            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault());
            Console.WriteLine("HasValue: " + date.HasValue);
           //Console.WriteLine("Value: ", date.Value);


            DateTime? date2 = new DateTime(2023, 1, 1);
            Console.WriteLine(date2);

            DateTime date3 = date2.GetValueOrDefault();
            Console.WriteLine(date3);

            DateTime? date4 = date3;
            Console.WriteLine(date4);

            DateTime? date5 = null;
            if (date5.HasValue)
                date5 = date5.Value;
            else
                date5 = DateTime.Today;
            Console.WriteLine(date5);

            DateTime? date6 = date5 ?? DateTime.Today;
            Console.WriteLine(date6);

        }
    }
}
