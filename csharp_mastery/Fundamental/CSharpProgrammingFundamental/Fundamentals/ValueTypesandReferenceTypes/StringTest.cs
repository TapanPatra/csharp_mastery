using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace CSharpFundamentals.DataTypes
{
   public  class StringTest
    {

        [Test]
        public void DifferentEqualObjects()
        {
            string x = "hello";
            x = x.Replace('h', 'j');

            object o1 = x;
            object o2 = "jello";
            Assert.AreNotSame(o1, o2);
            Assert.IsFalse(o1 == o2);
            Assert.IsTrue(o1.Equals(o2));

        }

        [Test]
        public void DifferentEqualStrings()
        {
            string x = "hello";
            x = x.Replace('h', 'j');
            string s1 = x;
            string s2 = "jello";
            Assert.AreNotSame(s1, s2);
            Assert.IsTrue(s1 == s2);
            Assert.IsTrue(s1.Equals(s2));
            Assert.IsTrue(object.Equals(s1, s2));

        }

        [Test]
        public void StringLength()
        {
            string x = "hello";
            Assert.AreEqual(5, x.Length);
            string y = x;
        }

        [Test]
        public void AssignmentAndReplacement()
        {
            string x = "hello";
            string y = x;
            x = x.Replace('h', 'j');
            Assert.AreEqual("jello", x);
            Assert.AreEqual("hello", y);

        }

        [Test]
        public void StringInterningOfConstants()
        {
            string x = "hello";
            string y = "hello";

            Assert.AreSame(x, y);
        }


        [Test]
        public void StringInterningOfConcatenation()
        {
            string x = "hello";
            string y = "he" + "llo";

            Assert.AreSame(x, y);

        }

        [Test]
        public void StringInterningOfNonConstants()
        {
            string x = "hello";
            string he = "he";
            string y = he + "llo";

            Assert.AreNotSame(x, y);


        }

        [Test]
        public void BadConacatenation()
        {
            string simple = new string('x', 10000);
            string bad = "";

            for (int i = 0; i < 10000; i++)
            {
                bad = bad + "x";
            }

            Assert.AreEqual(simple, bad);


        }

        [Test]
        public void GoodConcatenation()
        {
            string simple = new string('x', 10000);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                builder.Append("x");
            }

            string good = builder.ToString();
            builder.Append("This is not same as good");

            Assert.AreEqual(simple, good);
        }

        [Test]
        public void BadUseOfStringBuilder()
        {
            string x = "x";
            string y = "y";

            StringBuilder builder = new StringBuilder();

            builder.Append(x);
            builder.Append(" ");
            builder.Append(y);
            string result = builder.ToString();

            Assert.AreEqual("x y", result);

        }

        [Test]
        public void GoodUseOfConcatenation()
        {
            string x = "x";
            string y = "y";
            string result = x + " " + y;

            Assert.AreEqual("x y", result);
        }

        [Test]
        public void CompilerTransalationOfConcatenation()
        {
            string x = "x";
            string y = "y";
            string result = string.Concat(x, " ", y);

            Assert.AreEqual("x y", result);
        }

        [Test]
        public void StringJoin()
        {
            string[] values = { "x", "y" };
            string commaSeparated = string.Join(",", values);
            Assert.AreEqual("x,y", commaSeparated);
        }

        [Test]
        public void StringFormat()
        {
            string s1 = "x";
            string s2 = "y";

            string result = string.Format("{0} {1}", s1, s2);

            Assert.AreEqual("x y", result);

        }

        [Test]
        public void StringFormat1()
        {
            int value = 100;
            string s2 = "y";

            string result = string.Format("value={0} s2={1}", value, s2);
            Assert.AreEqual("value=100 s2=y", result);

        }

        [Test]
        public void StringFormat2()
        {
            decimal value = 10.5m;
            string s2 = "y";

            string result = string.Format("value={0:C} s2={1}", value, s2);
            Assert.AreEqual("value=$10.50 s2=y", result);

        }

        [Test]
        public void StringFormat3()
        {
            int value = 100;
            string s2 = "y";

            string result = string.Format("value=0x{0:X} s2={1}", value, s2);
            Assert.AreEqual("value=0x64 s2=y", result);

        }

        [Test]
        public void InternMethod()
        {
            string x = "hello";
            string y = "jello".Replace("j", "h");
            Assert.AreNotSame(x, y);
            Assert.AreSame(x, string.IsInterned(y));
            string z = "hello";
            Assert.AreSame(x, z);
            string z1 = string.Intern(y);
            Assert.AreSame(x, z1);

        }

        [Test]
        public void IsInterned()
        {
            string x = "hello".Replace("h", "j");
            // confused with this
            Assert.IsNull(string.IsInterned(x));
            string y = "yellow";
            Assert.IsNotNull(string.IsInterned(y));

        }

        [Test]
        public void SubString()
        {
            string x = "hello";
            string substring = x.Substring(1, 3);
            Assert.AreEqual("ell", substring);

            string substring2 = x.Substring(3);
            Assert.AreEqual("lo", substring2);
        }

        [Test]
        public void StringIndexOf()
        {
            string s1 = "helllo";
            var firstllIndex = s1.IndexOf("ll");
            Console.WriteLine(firstllIndex);
            var secondllIndex = s1.IndexOf("ll", firstllIndex + 1);
            Console.WriteLine(secondllIndex);
            var secondllIndex2 = s1.IndexOf("ll", firstllIndex + 2);
            Console.WriteLine(secondllIndex2);
        }

        [Test]
        public void StringSplit()
        {
            string myName = "Tapan-Kumar Patra";

            char[] spliters = { ' ', '-' };

            string[] words = myName.Split(spliters, 2);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

        }

        [Test]
        public void StringSplitUsingRegexp()
        {
            string text = "Tapan1Kumar2Patra";
            string patternText = @"\d";
            Regex pattern = new Regex(patternText);

            string[] words = pattern.Split(text);

            foreach (var word in words)
            {
                Console.WriteLine(word);

            }

        }

        [Test]
        public void RegexMatch()
        {


            string sampleLine = "WARNING 07/09/2018 14:42:53 ---FooBar--- The foo has been barred";

            Regex pattern = new Regex(@"(?<level>\S+) " +
                                      @"(?<timestamp>[0-9]{2}/[0-9]{2}/[0-9]{4} [0-9]{2}:[0-9]{2}:[0-9]{2}) " +
                                      @"---(?<category>[^-]+)--- " +
                                      @"(?<message>.*)");

            Match match = pattern.Match(sampleLine);

            if (match.Success)
            {
                Console.WriteLine(match.Groups["level"]);
                Console.WriteLine(match.Groups["category"]);

                string timestamp = match.Groups["timestamp"].Value;
                Console.WriteLine(timestamp);
                DateTime dateTime = DateTime.ParseExact(timestamp, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime date = dateTime.Date;
                Console.WriteLine(date);

                Console.WriteLine(match.Groups["message"]);

            }

            else
            {
                Console.WriteLine("Match not found");
            }

        }

        [Test]
        public void RegexMatchDate()
        {


            string sampleLine = "07/09/2018 14:42:53 ";

            Regex pattern = new Regex(@"(?<timestamp>[0-9]{2}/[0-9]{2}/[0-9]{4} [0-9]{2}:[0-9]{2}:[0-9]{2}) ");

            Match match = pattern.Match(sampleLine);

            if (match.Success)
            {
                Console.WriteLine(match.Groups["timestamp"]);

            }

            else
            {
                Console.WriteLine("Match not found");
            }

        }

        [Test]
        public void StringEncoding()
        {
            string text = "Cafe/";
            Assert.AreEqual("/efaC", Reverse(text));
        }

        private string Reverse(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }


        [Test]
        public void EncodedString()
        {
            Encoding encoding = Encoding.UTF8;

            string text = "ABC";

            byte[] bytes = encoding.GetBytes(text);

            string reconstituted = Encoding.UTF8.GetString(bytes);

            Assert.AreEqual(text, reconstituted);
        }

        [Test]
        public void EncodedString2()
        {
            MD5.Create();
            using (var md5 = MD5.Create())
            {
                byte[] hash = new byte[2]; 
                string hashAsText = Convert.ToBase64String(hash);
                Console.WriteLine(hashAsText);
                byte[] backAgain = Convert.FromBase64String(hashAsText);

            }
        }

        [Test]
        public void Culture()
        {
            CultureInfo turkish = CultureInfo.CreateSpecificCulture("tr");
            Thread.CurrentThread.CurrentCulture = turkish;

            string MailHeader = "MAIL";
            string header = "mail";

            bool isMailHeader = header.Equals(MailHeader, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(isMailHeader);

        }

        [Test]
        public void Print_How_Many_Times_String_Apperas_in_StringArray()
        {
            /*
             *Given a list of Strings and a specific String, find out many times the String appears in the list
            Example:
            l = {"abc", "def", "abc", "ghi"}
            s = "abc"
            output = 2 
            */
            string[] words = new string[] { "abc", "def", "abc", "ghi" };
            string match = "abc";
            Assert.AreEqual(2, MatchCount(words, match));
        }

        private int MatchCount(string[] words, string match)
        {
            int count = 0;
            foreach (var word in words)
            {
                if (word.Equals(match))
                {
                    count++;
                }
            }
            return count;
        }
    }
}