[TestFixture]
public class AnonymousMethodsTest
{
    [Test]
    public void UseAnonymousMethod()
    {
        Func<int, int, int> multiply = delegate (int x, int y)
        {
            return x * y;
        };

        int result = multiply(3, 5);
        Console.WriteLine($"Multiply: {result}");
        Assert.That(result, Is.EqualTo(15));
    }
}
