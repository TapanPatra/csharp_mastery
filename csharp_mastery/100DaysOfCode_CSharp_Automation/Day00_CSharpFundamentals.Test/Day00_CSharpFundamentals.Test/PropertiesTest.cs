public class Person
{
    public string Name { get; set; }
}

[TestFixture]
public class PropertiesTest
{
    [Test]
    public void AutoPropertyTest()
    {
        var person = new Person { Name = "Alice" };
        Console.WriteLine($"Name: {person.Name}");
        Assert.That(person.Name, Is.EqualTo("Alice"));
    }
}
