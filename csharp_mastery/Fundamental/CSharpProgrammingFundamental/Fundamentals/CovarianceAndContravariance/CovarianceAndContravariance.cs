using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fundamentals
{
    public class Auto
    {

    }

    public class Sedan : Auto
    {

    }

    public class Roadster : Auto
    {

    }

    public class City : Sedan
    {

    }


    [TestFixture]
    public class CovarianceTest
    {
        [Test]
        public void ReferenceCovariance()
        {
            Sedan city = new Sedan();
            Auto car = city;

        }
        [Test]
        public void ArrayCovariance()
        {
            Sedan[] sedans = new Sedan[1];
            sedans[0] = new Sedan();

            Auto[] autos = sedans;
            autos[0] = new Roadster();//Attempted to access an element as a type incompatible with the array.

        }

        [Test]
        public void GenericCovarianceTest()
        {
            MyFirstList<Sedan> sedans = new MyFirstList<Sedan>();
            sedans.Add(new Sedan());
            PerformService(sedans);
        }

        public void PerformService(IFirstItem<Auto> autos)
        {

        }
    }
}
