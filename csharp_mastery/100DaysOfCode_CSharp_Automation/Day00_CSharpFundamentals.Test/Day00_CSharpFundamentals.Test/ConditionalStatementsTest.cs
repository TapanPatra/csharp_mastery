[TestFixture]
public class ConditionalStatementsTest
{
    [Test]
    public void IfElseConditionTest()
    {
        int x = 10;
        string result = (x > 5) ? "Greater" : "Smaller";
        Console.WriteLine(result);
        Assert.That(result, Is.EqualTo("Greater"));
    }
}
