using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    public class HttpCookie
    {
        private readonly Dictionary<string, string> _dictionary;
        public DateTime Expiry { get; set; }

        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public void SetItem(string key, string value)
        {

        }

        public string GetItem(string key)
        {
           throw new NotImplementedException();
        }

        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }

        // Indexer overloading to get values using integer indices
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < _dictionary.Count)
                {
                    int i = 0;
                    foreach (var pair in _dictionary)
                    {
                        if (i == index)
                        {
                            return pair.Value;
                        }
                        i++;
                    }
                }
                throw new IndexOutOfRangeException();
            }
        }
    }

    [TestFixture]
    public class IndexerTest
    {

        [Test]
        public void GetSetIndexer()
        {
            var cookie = new HttpCookie();
            cookie["name"] = "Mosh";
            cookie["age"] = "30";

            Console.WriteLine("Name: " + cookie["name"]);
            Console.WriteLine("Age: " + cookie["age"]);

            Console.WriteLine("First Value: " + cookie[0]);
            Console.WriteLine("Second Value: " + cookie[1]);
        }
    }
}
