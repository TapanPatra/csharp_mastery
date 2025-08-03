[TestFixture]
public class VariableTest
{
    [Test]
    public void DefineAndPrintAllTypes()
    {
        int i = 42;
        float f = 3.14f;
        double d = 3.1415;
        char c = 'A';
        string s = "Hello";
        bool b = true;
        decimal m = 99.99m;

        Console.WriteLine($"{i}, {f}, {d}, {c}, {s}, {b}, {m}");
        Assert.Pass();
    }
}
