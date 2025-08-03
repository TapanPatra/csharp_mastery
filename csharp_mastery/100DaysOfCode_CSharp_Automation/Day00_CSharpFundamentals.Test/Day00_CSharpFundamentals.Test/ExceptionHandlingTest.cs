[TestFixture]
public class ExceptionHandlingTest
{
    [Test]
    public void HandleDivideByZero()
    {
        try
        {
            int x = 10 / int.Parse("0");
            Assert.Fail("Exception not thrown");
        }
        catch (DivideByZeroException)
        {
            Assert.Pass("Caught DivideByZeroException");
        }
    }
}
