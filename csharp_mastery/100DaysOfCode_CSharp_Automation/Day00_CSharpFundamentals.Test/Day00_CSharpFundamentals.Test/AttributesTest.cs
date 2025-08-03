[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class InfoAttribute : Attribute
{
    public string Description { get; }
    public InfoAttribute(string desc) => Description = desc;
}

[Info("Sample class with Info attribute")]
public class MyClassWithAttribute { }

[TestFixture]
public class AttributesTest
{
    [Test]
    public void CustomAttributeReflectionTest()
    {
        var attr = (InfoAttribute)Attribute.GetCustomAttribute(typeof(MyClassWithAttribute), typeof(InfoAttribute));
        Console.WriteLine($"Description: {attr?.Description}");
        Assert.That(attr?.Description, Is.EqualTo("Sample class with Info attribute"));
    }
}
