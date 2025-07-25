using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{

    public class Book
    {
        public string Name { get; }

        public Book(string name) => Name = name;

        //public override string ToString() => $"Title: {Name}";
    }


    [TestFixture]
    public class BookTest
    {
        [Test]
        public void SystemObjectTest()
        {
            var obj = new object();

            Type t = obj.GetType();
            Console.WriteLine(t.FullName);

            Console.WriteLine(obj.ToString());

            var book = new Book("Code Complete");
            Console.WriteLine(book);

            var list = new ArrayList();
            list.Add(obj);
            list.Add(book);
            list.Add(3);

            book = (Book)obj;

            if (obj is Book b)
            {
                Console.WriteLine(b.Name);
            }

            var array = new List<int>();
            array.Add(1);

            int n = 10;
            obj = n;       // boxing
            n = (int)obj;  // unboxing
        }
    }

}
