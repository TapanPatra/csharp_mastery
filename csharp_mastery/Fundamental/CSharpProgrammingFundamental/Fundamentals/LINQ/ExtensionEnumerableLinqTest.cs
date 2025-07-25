using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharpFundamentals.DataTypes;
using NUnit.Framework;
namespace Fundamentals
{
    public static class Extensions
    {
        public static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static byte[] ReadFully(Stream input)
        {
            MemoryStream output = new MemoryStream();
            byte[] buffer = new byte[8192];
            int bytesread;

            while ((bytesread = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesread);
            }

            return output.ToArray();
        }

        public static string EReverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static byte[] EReadFully(this Stream input)
        {
            MemoryStream output = new MemoryStream();
            byte[] buffer = new byte[8192];
            int bytesread;

            while ((bytesread = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesread);
            }

            return output.ToArray();
        }

        public static int DoubleLength(this string input)
        {
            return input.Length * 2;
        }
    }

    public static class MasteringEnumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
                                                                           Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
                                                                   Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }


    }

    [TestFixture]
    public class ExtensionsTest
    {



        [Test]
        public void InvokeReverse()
        {
            string reversed = Extensions.Reverse("hello");
            Assert.AreEqual("olleh", reversed);

        }

        [Test]
        public void ReadFully()
        {
            var request = WebRequest.Create("http://www.google.com");
            using (var response = request.GetResponse())
            {
                using (var responsestream = response.GetResponseStream())
                {
                    byte[] data = Extensions.ReadFully(responsestream);
                    Console.WriteLine(data.Length);
                }

            }
        }

        [Test]
        public void InvokeReverseUsingExtension()
        {
            string reversed = "hello".EReverse();
            string reversed2 = Extensions.Reverse("hello");
            Assert.AreEqual("olleh", reversed);

        }

        [Test]
        public void ReadFullyUsingExtension()
        {
            var request = WebRequest.Create("http://www.google.com");
            using (var response = request.GetResponse())
            {
                using (var responsestream = response.GetResponseStream())
                {
                    byte[] data = responsestream.EReadFully();
                    Console.WriteLine(data.Length);
                }

            }
        }

        [Test]
        public void MiniLinq()
        {
            string[] names = { "Tapan", "Halikul", "Ammiraju", "Sapan", "Mani" };

            var query = names.Select(x => x.Length)
                             .Where(x => x > 5);

            foreach (var result in query)
            {
                Console.WriteLine(result);
            }


            var query2 = names.Where(x => x.EndsWith("n"))
                              .Select(x => x.ToUpper());

            foreach (var result in query2)
            {
                Console.WriteLine(result);
            }


            string[] mynames = { "Holly", "Rob", "Jon", "Tom", "William" };

            var query3 = names.Where(x => !x.EndsWith("m"))
                              .Select(x => new
                              {
                                  UpperName = x.ToUpper(),
                                  NameLength = x.Length
                              });

            foreach (var result in query3)
            {
                Console.WriteLine(result);
            }

            var filtered = MasteringEnumerable.Where(names,
                                                        x => !x.EndsWith("m"));


            var query4 = MasteringEnumerable.Select(filtered,
                                                        x => new
                                                        {
                                                            UpperName = x.ToUpper(),
                                                            NameLength = x.Length
                                                        });


            foreach (var result in query4)
            {
                Console.WriteLine(result);
            }


            var query5 = from x in mynames
                         where !x.EndsWith("m")
                         select new { UpperName = x.ToUpper(), NameLength = x.Length };

            foreach (var result in query5)
            {
                Console.WriteLine(result);
            }




        }
    }

    [TestFixture]
    public class ExtensionEnumerableLinqTest
    {

        [Test]
        public void ReviewOfFeaturesUsedInLINQ()
        {
            //Annonymous Method and Type inference
            var person = new { FirstName = "Tapan", Age = 30 };
            Console.WriteLine(person);
            //Lambda Expression
            Func<string, bool> isLong = x => x.Length > 5;
            Console.WriteLine(isLong("TAPANPATRA"));

            //Extension Method
            int doubleLength = "foo".DoubleLength();
            Console.WriteLine(doubleLength);

        }

        [Test]
        public void OverviewOfLinq()
        {
            List<string> names = new List<string>
            {
                "Maninee, Family",
                "Tanmay, Family",
                "This is not valid",
                "Halikul, Collegue",
                "Uma, Friend"
            };

            Regex pattern = new Regex("([^,]*), (.*)");

            var query = from line in names
                        let match = pattern.Match(line)
                        where match.Success
                        select new
                        {
                            Name = match.Groups[1].Value,
                            RelationShip = match.Groups[2].Value
                        };

            foreach(var item in query)
            {
                Console.WriteLine(item);
            }

        }

        [Test]
        public void OverviewOfLinqGroupBy()
        {
            List<string> names = new List<string>
            {
                "Maninee, Family",
                "Tanmay, Family",
                "This is not valid",
                "Halikul, Collegue",
                "Uma, Friend"
            };

            Regex pattern = new Regex("([^,]*), (.*)");

            var query = from line in names
                        let match = pattern.Match(line)
                        where match.Success
                        select new
                        {
                            Name = match.Groups[1].Value,
                            RelationShip = match.Groups[2].Value
                        } into association
                        group association.Name by association.RelationShip;


            foreach (var grp in query)
            {
                Console.WriteLine("Relationship: {0}", grp.Key);
                foreach(var name in grp)
                {
                    Console.WriteLine("{0}", name);
                }
            }

        }

        [Test]
        public void CompilerVersionOfLinq()
        {
            List<string> names = new List<string>
            {
                "Maninee, Family",
                "Tanmay, Family",
                "This is not valid",
                "Halikul, Collegue",
                "Uma, Friend"
            };

            Regex pattern = new Regex("([^,]*), (.*)");

            var query = names.Select(line => new { line, match = pattern.Match(line) })
                             .Where(z => z.match.Success)
                             .Select(z => new
                             {
                                 Name = z.match.Groups[1].Value,
                                 RelationShip = z.match.Groups[2].Value
                             })
                             .GroupBy(association => association.RelationShip,
                                      association => association.Name);


            foreach (var grp in query)
            {
                Console.WriteLine("Relationship: {0}", grp.Key);
                foreach (var name in grp)
                {
                    Console.WriteLine("{0}", name);
                }
            }

        }

        [Test]
        public void UseOtherExpressionPatternInCodeNotLinq()
        {
            List<string> names = new List<string>
            {
                "Maninee, Family",
                "Tanmay, Family",
                "This is not valid",
                "Halikul, Collegue",
                "Uma, Friend"
            };

            Regex pattern = new Regex("([^,]*), (.*)");

            var queryLinq = from line in names
                            where line.Length < 15
                            select line;

            var queryExpressionPattern = names.Where(line => line.Length < 15);
        }

        [Test]
        public void OtherOperationsNotInQueryExpressions()
        {
            List<string> names = new List<string>
            {
                "Maninee, Family",
                "Tanmay, Family",
                "This is not valid",
                "Halikul, Collegue",
                "Uma, Friend"
            };

            var max = names.Max(name => name.Length);
            Console.WriteLine(max);
        }

    }


}
