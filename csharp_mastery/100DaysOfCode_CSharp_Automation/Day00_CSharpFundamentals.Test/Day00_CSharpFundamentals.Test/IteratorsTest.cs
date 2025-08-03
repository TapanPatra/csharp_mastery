public class NumberGenerator
{
    public IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
}

[TestFixture]
public class IteratorsTest
{
    [Test]
    public void UseYieldReturn()
    {
        var gen = new NumberGenerator();
        var result = gen.GetNumbers().ToList();

        Console.WriteLine(string.Join(", ", result));
        Assert.That(result.Count, Is.EqualTo(3));
    }
}
