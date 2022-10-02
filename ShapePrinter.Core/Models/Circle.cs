using System.Reflection;
using System.Text;
using ShapePrinter.Core.Models.Contract;

namespace ShapePrinter.Core.Models;

public sealed record Circle(uint Radius) : IShape
{
    public IEnumerable<string> GetView()
    {
        if (Radius == 0)
        {
            return Enumerable.Empty<string>();
        }

        return VariantOne();
    }

    private IEnumerable<string> VariantOne()
    {
        var diameter = Radius * 2;
        var bSquared = 4 * Radius * Radius;
        for (int i = 0; i <= diameter; i++)
        {
            var line = new StringBuilder();
            var d = bSquared - 4 * (Radius - i) * (Radius - i);
            var sqrt = Math.Sqrt(d);
            var x1 = (diameter + sqrt) / 2;
            var x2 = (diameter - sqrt) / 2;
            var minInt = (int)Math.Round(Math.Min(x1, x2));
            var maxInt = (int)Math.Round(Math.Max(x1, x2));
            for (int j = 0; j <= diameter; j++)
            {
                if (j == maxInt || j == minInt)
                {
                    line.Append("* ");
                }
                else
                {
                    line.Append("  ");
                }
            }

            yield return line.ToString().TrimEnd();  // remove trailing spaces on builder 
        }
    }
    
    private IEnumerable<string> VariantTwo()
    {
        var rUpper = (Radius + 0.25) * (Radius + 0.25) + 1;
        var rLower = (Radius - 1) * (Radius - 1) + 1;
        var diameter = Radius * 2;
        for (int i = 0; i <= diameter; i++)
        {
            var line = new StringBuilder();
            var y = Math.Pow(Radius - i, 2);
            for (int j = 0; j <= diameter; j++)
            {
                var x = Math.Pow(Radius - j, 2);
                var symbol = x + y < rUpper && x + y > rLower
                    ? "* "
                    : "  ";
                line.Append(symbol);
            }

            yield return line.ToString().TrimEnd(); // remove trailing spaces on builder 
        }
    }
}


