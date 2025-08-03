[TestFixture]
public class EnumeratorsTest
{
    [Test]
    public void ManualEnumeratorTest()
    {
        var list = new List<int> { 1, 2, 3 };
        var enumerator = list.GetEnumerator();
        int count = 0;

        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
            count++;
        }

        Assert.That(count, Is.EqualTo(3));
    }
}
