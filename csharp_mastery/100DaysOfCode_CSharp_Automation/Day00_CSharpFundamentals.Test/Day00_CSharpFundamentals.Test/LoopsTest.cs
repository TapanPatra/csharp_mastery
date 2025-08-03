[TestFixture]
public class LoopsTest
{
    [Test]
    public void ForLoopTest()
    {
        int sum = 0;
        for (int i = 1; i <= 5; i++)
        {
            sum += i;
        }
        Console.WriteLine($"Sum: {sum}");
        Assert.That(sum, Is.EqualTo(15));
    }
}
