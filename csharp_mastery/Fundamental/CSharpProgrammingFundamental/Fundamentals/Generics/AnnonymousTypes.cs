using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fundamentals
{
    [TestFixture]
    class AnnonymousTypes
    {
        [Test]
        public void IntroductionToAnonymousTypes()
        {
            var person = new { FisrtName = "Tapan",
                               LastName = "Patra",
                               Address=new {Town="Hyderabad", State="Telegana" }
                             };
            Console.WriteLine(person);

            var person2 = new
            {
                FisrtName = "Tapan",
                LastName = "Patra",
                Address = new { Town = "Hyderabad", State = "Telegana" }
            };

            Assert.AreEqual(person, person2);
            Assert.AreEqual(person.GetHashCode(), person2.GetHashCode());

        }

        [Test]
        public void AnonymousTypesInsideTheCompiler()
        {
            var name = new { FirstName = "One", LastName = "Two" };
            var weiredName = new { FirstName = 1, LastName = 2 };
            //Only one Type is created with generics
        }

        [Test]
        public void ImplicitlyTypedArrays()
        {
            var person = new { FisrtName = "Tapan", LastName = "Patra" };

            var people = new[] {
                                person,
                                new {FisrtName = "Tanmay", LastName = "Patra" }
                               };



        }

        private void DoSomething<T>(T[] values)
        {
            //
        }

        [Test]
        public void ImplicitlyTypedArrays2()
        {
            DoSomething(new[] { 1, 2, 3 });
            DoSomething(new[] { 1, 2.5, 3 });
        }

        private void DoSomething<T>(T value)
        {
            Console.WriteLine(typeof(T));
        }
        [Test]
        public void CallingAGenericMethod()
        {
            var person = new { FisrtName = "Tapan", LastName = "Patra" };
            DoSomething(person);

        }
    }

}
