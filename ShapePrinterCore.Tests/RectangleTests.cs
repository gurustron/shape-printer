using ShapePrinter.Core.Models;

namespace ShapePrinterCore.Tests;

public class RectangleTestsTests
{
    private static readonly object[] Cases =
    {
        new object[] { 0, 1, "" },
        new object[] { 0, 0, "" },
        new object[] { 1, 0, "" },
        new object[] { 10, 0, "" },
        new object[] { 0, 10, "" },
        new object[] { 1, 1, "*" },
        new object[]
        {
            2, 2,
@"*  *
*  *"
        },
        new object[]
        {
            3, 3,
@"*  *  *
*     *
*  *  *"
        },
        new object[]
        {
            4, 3,
@"*  *  *  *
*        *
*  *  *  *"
        },
        new object[]
        {
            3, 4, 
@"*  *  *
*     *
*     *
*  *  *"
        }
    };

    [TestCaseSource(nameof(Cases))]
    public void TestWithSize(int width, int height, string expected)
    {
        var square = new Rectangle((uint)width, (uint)height);
        var actual = string.Join(Environment.NewLine, square.GetView());
        Assert.That(actual, Is.EqualTo(expected));
    }
}