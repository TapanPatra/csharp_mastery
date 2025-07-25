using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ValueTypesandReferenceTypes
{
    [TestFixture]
    public class TypeConversion
    {
        [Test]
        public void ConvertStringToInt()
        {
            var number = "1234";
            var result = Convert.ToInt32(number);
            Console.WriteLine(result);
        }

        [Test]
        public void TryParse()
        {
            string parseResultSummary;
            string stringFirst = "28";
            int intFirst;

            bool success = int.TryParse(stringFirst, out intFirst);
            parseResultSummary = success
                                        ? "was successfully parsed"
                                        : "was not successfully parsed";
            Console.WriteLine($"String {stringFirst} {parseResultSummary}");
            string stringSecond = "vt750";
            int intSecond;
            success = int.TryParse(stringSecond, out intSecond);
            parseResultSummary = success
                                        ? "was successfully parsed"
                                        : "was not successfully parsed";
            Console.WriteLine($"String {stringSecond} {parseResultSummary}");
        }                                    
    }
}
