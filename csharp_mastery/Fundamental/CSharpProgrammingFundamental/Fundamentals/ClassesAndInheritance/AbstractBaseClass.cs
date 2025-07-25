using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{
    public abstract class Dancer :IControllable
    {
        private readonly string name;

        protected Dancer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public abstract void Dance();

        public void DanceTwice()
        {
            Dance();
            Dance();
        }

        public void Start()
        {
            Console.WriteLine("Staring Dance");
            Dance();
        }

        public abstract void Stop();
        
        
    }

    public class TapDancer : Dancer
    {

        public TapDancer() : base("tap dancer")
        {

        }

        public override void Dance()
        {
            Console.WriteLine("Drip, Drip");
        }

        public override void Stop()
        {
            Console.WriteLine("ddddd ddddd");
        }
    }

    public sealed class ChainShawDancer : IControllable
    {
        public void Start()
        {
            Console.WriteLine("Starting Dance");
            Console.WriteLine("Brim Brim Brim");
        }

        public void Stop()
        {
            Console.WriteLine("thid thud thud");
        }
    }


    [TestFixture]
    public class TapDancerTest
    {
        [Test]
        public void DefaultName()
        {
            Dancer dancer = new TapDancer();
            Assert.AreEqual("tap dancer", dancer.Name);
        }

        [Test]
        public void DanceByDance()
        {
            Dancer dancer = new TapDancer();
            dancer.Dance();
        }

        [Test]
        public void DanceTwice()
        {
            Dancer dancer = new TapDancer();
            dancer.DanceTwice();
        }
    }


}
