using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{

    public class BaseClass
    {

        private readonly string name;

        public BaseClass() : this("default")
        {

        }

        public BaseClass(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }

        }
        public virtual int CalculateResult(int x)
        {
            return x * 2;
        }

        public int TripleInput(int x)
        {
            return x * 3;
        }
    }


    public class DerivedClass : BaseClass
    {

        public DerivedClass() : base ("derived default")
        {

        }

        public DerivedClass(string name) : base ("derived " + name)
        {

        }

        public override int CalculateResult(int x)
        {
            return x / 2;
        }

        public int QuadarapleInput(int x)
        {
            return x * 4;
        }
    }


    [TestFixture]
    public class BaseClassTest
    {
        [Test]
        public void CalculateDoubleInput()
        {
            BaseClass test = new BaseClass();
            Assert.AreEqual(16, test.CalculateResult(8));
        }

        [Test]
        public void CalculateTripleInput()
        {
            BaseClass test = new BaseClass();
            Assert.AreEqual(24, test.TripleInput(8));
        }

        [Test]
        public void NameDefaultToDefault()
        {
            BaseClass test = new BaseClass();
            Assert.AreEqual("default", test.Name);
        }

        [Test]
        public void SpecifiedNameIsPrpagated()
        {
            BaseClass test = new BaseClass("Tapan");
            Assert.AreEqual("Tapan", test.Name);
        }
    }

    [TestFixture]
    public class DerivedClassTest
    {
        [Test]
        public void DefaultName()
        {
            BaseClass test = new DerivedClass();
            Assert.AreEqual("derived default", test.Name);
        }

        [Test]
        public void SpecifiedNamePropagated()
        {
            BaseClass test = new DerivedClass("Tapan");
            Assert.AreEqual("derived Tapan", test.Name);
        }

        [Test]
        public void TripleInput()
        {
            BaseClass test = new BaseClass();
            Assert.AreEqual(15, test.TripleInput(5));
        }


        [Test]
        public void QuadarpleInput()
        {
            DerivedClass test = new DerivedClass();
            Assert.AreEqual(20, test.QuadarapleInput(5));
        }

        [Test]
        public void CalculateResult()
        {
            DerivedClass test = new DerivedClass();
            Assert.AreEqual(4, test.CalculateResult(8));
        }
    }


}


