using NUnit.Framework.Legacy;

[TestFixture]
public class ListTest
{
    [Test]
    public void AddAndRemoveItems()
    {
        var fruits = new List<string> { "Apple", "Banana" };
        fruits.Add("Cherry");
        fruits.Remove("Banana");

        Console.WriteLine(string.Join(", ", fruits));
        CollectionAssert.AreEqual(new[] { "Apple", "Cherry" }, fruits);
    }
}
