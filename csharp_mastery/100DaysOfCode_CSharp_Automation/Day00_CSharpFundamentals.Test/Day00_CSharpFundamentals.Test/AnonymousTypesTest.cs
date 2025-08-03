[TestFixture]
public class AnonymousTypesTest
{
    [Test]
    public void CreateAnonymousType()
    {
        var person = new { Name = "John", Age = 30 };
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

        Assert.Multiple(() =>
        {
            Assert.That(person.Name, Is.EqualTo("John"));
            Assert.That(person.Age, Is.EqualTo(30));
        });
    }
}
