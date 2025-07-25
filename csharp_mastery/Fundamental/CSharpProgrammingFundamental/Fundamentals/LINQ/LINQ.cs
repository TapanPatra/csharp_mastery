using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._03_Fundamentals.LINQ
{
    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book()  {Title ="ADO .NET Step by step", Price=5 },
                new Book()  {Title ="ADO .NET MVC", Price=9.99f },
                new Book()  {Title ="ADO .NET Web API", Price=12 },
                new Book()  {Title ="C# Advanced", Price=7 },
                new Book()  {Title ="C# Advanced", Price=9  },
                new Book()  {Title ="ADO .NET Step by step", Price=10 }
            };
        }
           
    }

    [TestFixture]
    public class LinqTest
    {
        [Test]
        public void PrintCheapBookWithoutLinq()
        {
            var books = new BookRepository().GetBooks();

            var cheapBooks = new List<Book>();

            foreach (var book in books)
            {
                if(book.Price < 10)
                cheapBooks.Add(book);
            }

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title + " " + book.Price);
            }
        }

        [Test]
        public void PrintCheapBookLinqExtensionMethod()
        {
            var books = new BookRepository().GetBooks();

            var cheapBooks = books
                 .Where(b => b.Price < 10)
                 .OrderBy(b => b.Price)
                 .Select(b => b.Title);


            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book);
            }
        }

        [Test]
        public void PrintCheapBookLinqQueryOperator()
        {
            var books = new BookRepository().GetBooks();

            var cheapBooks = from book in books
                             where book.Price < 10
                             orderby book.Price
                             select book.Title;


            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book);
            }
        }

        [Test]
        public void LinqExtensionMethods()
        {
            var books = new BookRepository().GetBooks();

            var book = books.Single(b => b.Title == "ASP .NET MVC");
            Console.WriteLine(book.Price);

            var book2 = books.SingleOrDefault(b => b.Title == "ASP .NET MVC");
            Console.WriteLine(book2 == null);

            var book3 = books.First(b => b.Title == "ASP .NET MVC");
            Console.WriteLine(book3.Price);

            var book4 = books.FirstOrDefault(b => b.Title == "ASP .NET MVC");
            Console.WriteLine(book4 == null);

            var pagedBooks = books.Skip(1).Take(1);
            foreach (var b in pagedBooks)
            {
                Console.WriteLine(b.Title);
            }

            var count = books.Count();
            var maxPrice = books.Max(b => b.Price);
            var mincPrice = books.Min(b => b.Price);
            var totalPrice = books.Sum(b => b.Price);
            var avgPrice = books.Average(b => b.Price);

        }

        [Test]
        public void AnonymousTypes()
        {
            var student = new { Name = "Mary Jones", Age = 19, Major = "History" };
            Console.WriteLine($"{student.Name}, Age {student.Age}, Major: {student.Major}");
        }
    }




}
