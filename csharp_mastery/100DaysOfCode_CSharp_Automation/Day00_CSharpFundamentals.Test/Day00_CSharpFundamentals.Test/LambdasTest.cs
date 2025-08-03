[TestFixture]
public class LambdasTest
{
    [Test]
    public void LambdaExpressionTest()
    {
        Func<int, int, int> subtract = (a, b) => a - b;
        int result = subtract(10, 3);

        Console.WriteLine($"Subtract: {result}");
        Assert.That(result, Is.EqualTo(7));
    }
}
