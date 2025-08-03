public struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y) { X = x; Y = y; }
}

[TestFixture]
public class StructsTest
{
    [Test]
    public void CreateAndUseStruct()
    {
        var p = new Point(3, 4);
        Console.WriteLine($"X: {p.X}, Y: {p.Y}");
        Assert.That(p.X + p.Y, Is.EqualTo(7));
    }
}
