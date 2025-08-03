[TestFixture]
public class DynamicTest
{
    [Test]
    public void DynamicTypeTest()
    {
        dynamic val = "Dynamic Value";
        int length = val.Length;

        Console.WriteLine($"Length: {length}");
        Assert.That(length, Is.EqualTo(13));
    }
}
