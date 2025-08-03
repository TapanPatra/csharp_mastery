using NUnit.Framework.Legacy;

[TestFixture]
public class RangesTest
{
    [Test]
    public void SliceArrayWithRange()
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5 };
        int[] slice = numbers[2..5]; // {2, 3, 4}

        Console.WriteLine(string.Join(", ", slice));
        CollectionAssert.AreEqual(new[] { 2, 3, 4 }, slice);
    }
}
