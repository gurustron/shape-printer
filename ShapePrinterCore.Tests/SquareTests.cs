using ShapePrinter.Core.Models;

namespace ShapePrinterCore.Tests;

public class SquareTests
{
    [Test]
    public void SquareSize0() => TestWithSize(0, "");

    [Test]
    public void SquareSize1() => TestWithSize(1, "*");
    
    [Test]
    public void SquareSize2() => TestWithSize(2, 
@"**
**");
    [Test]
    public void SquareSize3() => TestWithSize(3, 
@"***
* *
***");
    
    private static void TestWithSize(uint size, string expected)
    {
        var square = new Square(size);
        var actual = string.Join(Environment.NewLine, square.GetView());
        Assert.That(actual, Is.EqualTo(expected));
    }
}