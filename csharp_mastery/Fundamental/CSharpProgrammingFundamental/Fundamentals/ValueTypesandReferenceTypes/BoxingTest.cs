using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ValueTypesandReferenceTypes
{
    [TestFixture]
    public class BoxingTest
    {
        [Test]
        public void BoxingUnboxingTest()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add("Mosh");
            list.Add(DateTime.Today);

            var anotherList = new List<int>();
            var names = new List<string>();
        }
    }
}
