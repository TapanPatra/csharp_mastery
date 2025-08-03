public class Sample
{
    public string SayHello() => "Hello from Reflection";
}

[TestFixture]
public class ReflectionTest
{
    [Test]
    public void UseReflectionToInvokeMethod()
    {
        var type = typeof(Sample);
        var instance = Activator.CreateInstance(type);
        var method = type.GetMethod("SayHello");
        var result = method?.Invoke(instance, null);

        Console.WriteLine(result);
        Assert.That(result, Is.EqualTo("Hello from Reflection"));
    }
}
