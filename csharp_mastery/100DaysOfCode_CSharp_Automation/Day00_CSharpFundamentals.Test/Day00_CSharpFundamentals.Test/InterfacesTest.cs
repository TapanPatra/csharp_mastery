public interface IShape
{
    double Area();
}

public class Square : IShape
{
    public double Side { get; set; }
    public double Area() => Side * Side;
}

[TestFixture]
public class InterfacesTest
{
    [Test]
    public void InterfaceImplementationTest()
    {
        IShape shape = new Square { Side = 5 };
        double area = shape.Area();
        Console.WriteLine($"Area: {area}");
        Assert.That(area, Is.EqualTo(25));
    }
}
