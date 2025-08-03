public class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }
}

[TestFixture]
public class PropertyPatternTest
{
    [Test]
    public void MatchWithPropertyPattern()
    {
        var car = new Car { Brand = "Toyota", Year = 2022 };
        bool isModern = car is { Year: >= 2020 };

        Console.WriteLine($"Is Modern: {isModern}");
        Assert.That(isModern, Is.True);
    }
}
