using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{
    public class StreamSummer
    {

        public int Sum(Stream stream)
        {

            int value;
            int result = 0;

            while( (value=stream.ReadByte()) != -1)
            {
                result += value;
            }

            return result;
        }
    }

    [TestFixture]
    public class StreamSummerClassTest
    {
        [Test]
        public void StreamMemoryTest()
        {
            byte[] bytes = new byte[] { 2, 3, 4 };

            MemoryStream memoryStream = new MemoryStream(bytes);
            StreamSummer test = new StreamSummer();
            Assert.AreEqual(9, test.Sum(memoryStream));

        }
    }
}
