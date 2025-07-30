using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Day06_SeleniumAutomation
{
    public class RetryHandler : Attribute, IRepeatTest
    {
        private int _count;
        public RetryHandler(int count) => _count = count;

        public TestResult Execute(ITest test, TestExecutionContext context)
        {
            for (int i = 1; i <= _count; i++)
            {
                context.CurrentRepeatCount = i - 1;
                //test.Run(context);

                if (context.CurrentResult.ResultState == ResultState.Success)
                    break;
            }
            return context.CurrentResult;
        }

        TestCommand ICommandWrapper.Wrap(TestCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
