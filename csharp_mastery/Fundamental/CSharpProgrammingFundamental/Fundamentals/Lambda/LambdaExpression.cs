using CSharpFundamental._02_DataTypes.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Lambda
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book() {Title = "Title 1", Price = 5},
                new Book() {Title = "Title 2", Price = 7},
                new Book() {Title = "Title 3", Price = 15}
            };
        }
    }
    [TestFixture]
    public class LambdaExpression
    {
        [Test] 
        public void LambdaExpressionTest()
        {
            //args => expression
            // () => ...
            // x => ...
            //(x,y,z) => ...

            Func<int, int> square = number => number * number;

            Console.WriteLine($"Square of {5} is {square(5)}");
        }

        [Test] 
        public void GetCheaperBooks()
        {
            var books = new BookRepository().GetBooks();

            //var cheaperBooks = books.FindAll(IsCheaperThan10Dollar);
            var cheaperBooks = books.FindAll(book => book.Price < 10);

            foreach( Book book in cheaperBooks )
            {
                Console.WriteLine(book.Title);
            }
        }

        bool IsCheaperThan10Dollar(Book book)
        {
            return book.Price < 10;
        }
    }
}
