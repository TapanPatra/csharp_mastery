[TestFixture]
public class DateTimeTest
{
    [Test]
    public void DateTimeNowTest()
    {
        DateTime now = DateTime.Now;
        Console.WriteLine($"Now: {now}");
        Assert.That(now.Year, Is.GreaterThan(2000));
    }
}
