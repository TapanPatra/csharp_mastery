using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;

namespace CSharpFundamentals.DataTypes
{
    public static class StringExtension
    {
        public static string Shorten(this string str, int numOfWords)
        {
            if(numOfWords < 0)
            {
                throw new ArgumentOutOfRangeException("numOfWords should be greater than equal to 0");
            }

            if(numOfWords == 0)
            {
                return "";
            }

            var words = str.Split(' ');
            if(words.Length < numOfWords )
            {
                return str;
            }

            return string.Join(" ", words.Take(numOfWords)) + "...";
        }
    }

    [TestFixture]
    public class StringExtensionTest
    {
        [Test]
        public void ShortenTest()
        {
            string post = "This is supposed to be very long blog post";

            var shortenPost = post.Shorten(4);
            Console.WriteLine(shortenPost);

        }

        [Test]
        public void CalculateMax()
        {
            IEnumerable<int> numbers = new List<int>() { 1, 5, 2, 8, 11 };
            var max = numbers.Max();
            Console.WriteLine(max);
        }
    }

}
