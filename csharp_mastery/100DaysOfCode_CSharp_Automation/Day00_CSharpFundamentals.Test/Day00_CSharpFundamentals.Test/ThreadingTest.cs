[TestFixture]
public class ThreadingTest
{
    [Test]
    public void SimpleThreadExecution()
    {
        string message = "";
        var thread = new Thread(() => message = "Hello from thread");
        thread.Start();
        thread.Join();

        Console.WriteLine(message);
        Assert.That(message, Is.EqualTo("Hello from thread"));
    }
}
