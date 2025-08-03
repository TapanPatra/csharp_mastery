[TestFixture]
public class DictionaryTest
{
    [Test]
    public void AddAndRetrieveFromDictionary()
    {
        var dict = new Dictionary<string, int>
        {
            ["Apple"] = 1,
            ["Banana"] = 2
        };

        Console.WriteLine($"Banana = {dict["Banana"]}");
        Assert.That(dict["Banana"], Is.EqualTo(2));
    }
}
