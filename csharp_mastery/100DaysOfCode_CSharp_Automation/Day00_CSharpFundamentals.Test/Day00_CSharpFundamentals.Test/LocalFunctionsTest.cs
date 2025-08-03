[TestFixture]
public class LocalFunctionsTest
{
    [Test]
    public void UseLocalFunction()
    {
        int Add(int a, int b) => a + b;

        int result = Add(2, 3);
        Console.WriteLine($"Result: {result}");
        Assert.That(result, Is.EqualTo(5));
    }
}
