public record Employee(string Name, int Age);

[TestFixture]
public class WithExpressionTest
{
    [Test]
    public void CloneRecordWithChange()
    {
        var emp1 = new Employee("John", 30);
        var emp2 = emp1 with { Age = 35 };

        Console.WriteLine(emp2);
        Assert.That(emp2.Age, Is.EqualTo(35));
    }
}
