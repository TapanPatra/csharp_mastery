using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{
    interface IInfo
    {
        string GetAge();
        string GteName();
    }

    public class CA : IInfo
    {
        public string Name;
        public int Age;
        string IInfo.GetAge()
        {
            return Age.ToString();
        }

        string IInfo.GteName()
        {
            return Name;
        }

    }

    public class CB : IInfo
    {
        public string FirstName;
        public string LastName;
        public int Age;

        string IInfo.GetAge()
        {
            return Age.ToString();
        }

        string IInfo.GteName()
        {
            return FirstName + " " + LastName;
        }
    }

    [TestFixture]
    public class InterfaceIInfoTest
    {
       private void Print(IInfo item) 
       { 
            Console.WriteLine("Name: {0} Age:{1}", item.GteName(), item.GetAge()); 
       }

        [Test]
        public void PrintCaCbNameAndAge()
        {
            var ca = new CA() { Name = "Tapan Patra", Age = 35};
            var cb = new CB() { FirstName = "Tapan", LastName = "Patra", Age = 35};

            Print(ca);
            Print(cb);
        }

        
    }
}
