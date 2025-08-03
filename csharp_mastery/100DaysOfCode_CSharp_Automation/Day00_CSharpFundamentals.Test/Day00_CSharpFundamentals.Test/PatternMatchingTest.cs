[TestFixture]
public class PatternMatchingTest
{
    [Test]
    public void TypePatternMatch()
    {
        object obj = "Hello";
        if (obj is string str)
        {
            Console.WriteLine($"It's a string: {str}");
            Assert.That(str.Length, Is.EqualTo(5));
        }
    }
}
