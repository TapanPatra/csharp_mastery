[TestFixture]
public class FileIOTest
{
    [Test]
    public void WriteAndReadFile()
    {
        string path = "test.txt";
        File.WriteAllText(path, "Hello File");
        string content = File.ReadAllText(path);

        Console.WriteLine(content);
        Assert.That(content, Is.EqualTo("Hello File"));

        File.Delete(path); // Cleanup
    }
}
