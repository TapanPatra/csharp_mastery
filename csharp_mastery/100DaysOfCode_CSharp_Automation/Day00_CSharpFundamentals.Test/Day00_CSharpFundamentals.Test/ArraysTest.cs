[TestFixture]
public class ArraysTest
{
    [Test]
    public void ArrayInitializationTest()
    {
        int[] numbers = { 1, 2, 3, 4 };
        int sum = numbers.Sum();
        Console.WriteLine($"Sum: {sum}");
        Assert.That(sum, Is.EqualTo(10));
    }
}
