using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Generics
{
    struct PieceOfData<T> // Generic struct
    {
        public PieceOfData(T value) { _data = value; }
        private T _data;
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }


    [TestFixture]
    public class GenericStructs
    {
        [Test]
        public void GenericStruct()
        {
            var intData = new PieceOfData<int>(10);
            var stringData = new PieceOfData<string>("Hi there.");
            Console.WriteLine($"intData = {intData.Data}");
            Console.WriteLine($"stringData = {stringData.Data}");
        }
    }
}
