public class GenericBox<T>
{
    public T Value { get; set; }
}

[TestFixture]
public class GenericTest
{
    [Test]
    public void GenericTypeTest()
    {
        var intBox = new GenericBox<int> { Value = 100 };
        var stringBox = new GenericBox<string> { Value = "Hello" };

        Console.WriteLine($"Int: {intBox.Value}, String: {stringBox.Value}");
        Assert.Multiple(() =>
        {
            Assert.That(intBox.Value, Is.EqualTo(100));
            Assert.That(stringBox.Value, Is.EqualTo("Hello"));
        });
    }
}
