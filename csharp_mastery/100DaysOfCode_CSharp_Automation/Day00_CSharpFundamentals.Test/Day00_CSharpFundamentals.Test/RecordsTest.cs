public record Book(string Title, string Author);

[TestFixture]
public class RecordsTest
{
    [Test]
    public void CreateRecordAndVerify()
    {
        var book = new Book("1984", "George Orwell");
        Console.WriteLine(book);
        Assert.That(book.Title, Is.EqualTo("1984"));
    }
}
