public class Week
{
    private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public string this[int index] => days[index];
}

[TestFixture]
public class IndexersTest
{
    [Test]
    public void AccessViaIndexer()
    {
        var week = new Week();
        string day = week[1];
        Console.WriteLine($"Day: {day}");
        Assert.That(day, Is.EqualTo("Mon"));
    }
}
