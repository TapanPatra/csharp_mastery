using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Generics
{
    // where T : IComparable
    // where T : Product
    // where T : struct
    // where T : class
    // where T : new()
    public class Utilities <T> where T : IComparable, new()
    {
        public T Max (T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething()
        {
            object obj = new T();
        }

    }


    public class Product
    {
        public float Price { get; set; }
        public string Title { get; set; }
    }
    public class Book : Product
    {
        public string Isbn { get; set; }

    }

    public class DiscountCalculator <T> where T : Product
    {
        public float CalculateDiscount(T product)
        {
            return product.Price;
        }
    }

    public class Nullable<T> where T : struct
    {
        object _value;
        public Nullable()
        {

        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get {return _value != null; }


        }

        public T DefaultOrValue()
        {
            if (HasValue)
            {
                return (T)_value;
            }

            return default(T);
        }
    }
    public class GenericList<T>
    {
        public void Add(T item) 
        {
            
        }

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            
        }

    }

    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {
            //
        }
    }

    [TestFixture]
    public class GenericsTest
    {
        [Test]
        public void AddItemToGenericList()
        {
            var numbers = new GenericList<int>();
            numbers.Add(1);
            
            var books = new GenericList<Book>();
            books.Add(new Book());

        }

        [Test]
        public void AddItemToGenericDictionary()
        {
            var dict = new GenericDictionary<string, Book>();
            dict.Add("1234", new Book());


        }
        [Test]
        public void MaxTest()
        {
            var max = new Utilities<int>().Max(10, 20);
            Assert.AreEqual(20, max);
        }

        [Test]
        public void NullableTest() 
        { 
            var number = new Nullable<int>(5);
            Console.WriteLine("Has Value ?:" + number.HasValue);
            Console.WriteLine("Value of the number :" + number.DefaultOrValue());
        }
    }
}
