using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Interfaces
{
    interface IDataRetrieve
    {
        int GetData();
    }

    interface IDataStore
    {
        void SetData(int x);
    }

    public class MyData : IDataRetrieve, IDataStore
    {
        int Mem1;
        public int GetData()
        {
            return Mem1;
        }

        public void SetData(int x)
        {
            Mem1= x;
        }
    }

    [TestFixture]
    public class MyDataTest
    {
        [Test]
        public void GetMyData()
        {
            MyData data = new MyData();
            data.SetData(1);
            Console.WriteLine(data.GetData());
        }
    }

}
