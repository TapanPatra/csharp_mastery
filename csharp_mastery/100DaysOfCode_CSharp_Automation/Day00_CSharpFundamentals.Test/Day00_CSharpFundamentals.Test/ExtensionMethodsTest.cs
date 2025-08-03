public static class StringExtensions
{
    public static string ToUpperCase(this string input) => input.ToUpper();
}

[TestFixture]
public class ExtensionMethodsTest
{
    [Test]
    public void UseCustomExtensionMethod()
    {
        string original = "hello";
        string upper = original.ToUpperCase();
        Console.WriteLine(upper);
        Assert.That(upper, Is.EqualTo("HELLO"));
    }
}
