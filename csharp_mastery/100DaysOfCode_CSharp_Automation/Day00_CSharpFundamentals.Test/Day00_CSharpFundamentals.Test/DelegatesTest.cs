public delegate int Operation(int a, int b);

[TestFixture]
public class DelegatesTest
{
    [Test]
    public void DelegateInvocationTest()
    {
        Operation add = (a, b) => a + b;
        int result = add(4, 6);

        Console.WriteLine($"Result: {result}");
        Assert.That(result, Is.EqualTo(10));
    }
}
