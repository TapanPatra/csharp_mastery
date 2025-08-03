[TestFixture]
public class ConstantTest
{
    [Test]
    public void ConstantDefinition()
    {
        const int Pi = 3;
        Console.WriteLine($"Constant Pi: {Pi}");
        Assert.That(Pi, Is.EqualTo(3));
    }
}
