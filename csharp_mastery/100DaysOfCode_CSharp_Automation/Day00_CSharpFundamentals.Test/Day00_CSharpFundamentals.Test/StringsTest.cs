[TestFixture]
public class StringsTest
{
    [Test]
    public void StringConcatenationTest()
    {
        string first = "Hello";
        string second = "World";
        string result = first + " " + second;

        Console.WriteLine(result);
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void StringJoinTest()
    {
        var parts = new[] { "one", "two", "three" };
        string result = string.Join("-", parts);

        Console.WriteLine(result);
        Assert.That(result, Is.EqualTo("one-two-three"));
    }
}
