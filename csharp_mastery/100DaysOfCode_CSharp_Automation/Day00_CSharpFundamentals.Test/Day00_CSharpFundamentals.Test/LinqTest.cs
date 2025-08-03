using NUnit.Framework.Legacy;

[TestFixture]
public class LinqTest
{
    [Test]
    public void LinqWhereSelectTest()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var evens = numbers.Where(x => x % 2 == 0).Select(x => x * 10).ToList();

        Console.WriteLine(string.Join(", ", evens));
        CollectionAssert.AreEqual(new[] { 20, 40 }, evens);
    }
}
