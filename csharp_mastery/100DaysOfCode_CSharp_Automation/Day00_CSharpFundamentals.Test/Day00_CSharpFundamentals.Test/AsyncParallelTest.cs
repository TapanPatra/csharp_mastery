using System.Collections.Concurrent;

[TestFixture]
public class AsyncParallelTest
{
    private async Task<string> DownloadDataAsync()
    {
        await Task.Delay(500);
        return "Data downloaded";
    }

    [Test]
    public async Task AsyncAwaitTest()
    {
        string result = await DownloadDataAsync();
        Console.WriteLine(result);
        Assert.That(result, Is.EqualTo("Data downloaded"));
    }

    [Test]
    public void ParallelForEachTest()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        var bag = new ConcurrentBag<int>();

        Parallel.ForEach(numbers, n => bag.Add(n * 2));

        Console.WriteLine(string.Join(", ", bag));
        Assert.That(bag.Count, Is.EqualTo(5));
    }
}
