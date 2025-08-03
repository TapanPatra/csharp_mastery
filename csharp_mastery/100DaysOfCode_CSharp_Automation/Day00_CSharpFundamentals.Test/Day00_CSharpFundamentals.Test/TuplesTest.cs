[TestFixture]
public class TuplesTest
{
    [Test]
    public void CreateTupleAndAccessItems()
    {
        var tuple = (Name: "Alice", Age: 28);
        Console.WriteLine($"Name: {tuple.Name}, Age: {tuple.Age}");
        Assert.Multiple(() =>
        {
            Assert.That(tuple.Name, Is.EqualTo("Alice"));
            Assert.That(tuple.Age, Is.EqualTo(28));
        });
    }
}
