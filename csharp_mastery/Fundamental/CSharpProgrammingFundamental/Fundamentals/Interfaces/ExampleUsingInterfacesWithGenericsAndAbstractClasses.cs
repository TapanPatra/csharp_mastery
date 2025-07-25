using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.DataTypes
{
    public interface IControllable
    {
        void Start();
        void Stop();
    }

    public class StartAndStopper
    {

        public void StartAndStop(IControllable controllable)
        {
            controllable.Start();
            controllable.Stop();
        }
    }

    [TestFixture]
    public class StartAndStopTest
    {
        [Test]
        public void StartAndStop()
        {
            Dancer tapDance = new TapDancer();
            ChainShawDancer chainSaw = new ChainShawDancer();

            StartAndStopper test = new StartAndStopper();
            test.StartAndStop(tapDance);
            test.StartAndStop(chainSaw);
        }
    }

}
