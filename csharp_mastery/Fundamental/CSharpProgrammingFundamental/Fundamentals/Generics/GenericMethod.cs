using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{
    public class Shuffler
    {
        public static List<T> Shuffle<T>(List<T>list1, List<T> list2)
        {
            List<T> shuffled = new List<T>();
            for(int i =0; i < list1.Count; i++)
            {
                shuffled.Add(list1[i]);
                shuffled.Add(list2[i]);

            }

            return shuffled;

        }
    }

    [TestFixture]
    public class ShufflerTest
    {
        [Test]
        public void ShouldShuffleString()
        {
            List<string> list1 = new List<string>();
            list1.Add("One");
            list1.Add("Two");

            List<string> list2 = new List<string>();
            list2.Add("AAA");
            list2.Add("BBB");
            list2.Add("CCC");

            List<string> shuffled = Shuffler.Shuffle<string>(list1, list2);
            Console.WriteLine(shuffled.Count);
        }
    }

}
