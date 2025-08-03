public class Calculator
{
    public int Add(int a, int b) => a + b;
}

[TestFixture]
public class ClassTest
{
    [Test]
    public void CreateObjectAndCallMethod()
    {
        var calc = new Calculator();
        int result = calc.Add(5, 3);
        Assert.That(result, Is.EqualTo(8));
    }
}
