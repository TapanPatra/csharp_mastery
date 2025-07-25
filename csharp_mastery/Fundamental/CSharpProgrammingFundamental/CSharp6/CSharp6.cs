using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._05WhatIsNew.C_6
{
    [TestFixture]
    public class CSharp6
    {
        [Test]
        public void StringInterpolation()
        {
            double swanLakePrice = 100.0;
            Console.WriteLine($"The cost of a ticket to the ballet is {swanLakePrice:C}");

            string name = "Aiden";
            string technology = "Cold Fusion";
            string s;

            s = String.Format("{0} is working on {1}.", name, technology);
            Console.WriteLine(s);

            s = String.Format($"{name} is working on {technology}.");
            Console.WriteLine(s);
        }


    }
}
