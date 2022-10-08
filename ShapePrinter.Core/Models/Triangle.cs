using System.Diagnostics;
using System.Text;
using ShapePrinter.Core.Models.Contract;
using static ShapePrinter.Core.Helpers;

namespace ShapePrinter.Core.Models;

public sealed class Triangle : IShape
{
    public Triangle(double @base, double left, double right)
    {
        Base = Math.Round(@base);
        Left = left;
        Right = right;
    }

    public IEnumerable<string> GetView()
    {
        var baseLen = (uint)Math.Round(Base, MidpointRounding.ToZero);
        var leftAngle = Math.Acos((Left * Left + Base * Base - Right * Right) / (2 * Left * Base));
        var rightAngle = Math.Acos((Right * Right + Base * Base - Left * Left) / (2 * Right * Base));
        
        var height = (int) Math.Round(Math.Sin(leftAngle) * Left, MidpointRounding.AwayFromZero);

            
        for (int i = height; i > 1; i--)
        {
            var x1 = (int) Math.Round(i / Math.Tan(leftAngle), MidpointRounding.ToZero);   
            var x2 = baseLen - (int) Math.Round(i / Math.Tan(rightAngle), MidpointRounding.ToNegativeInfinity);
            var line = new StringBuilder();
            for (int j = 0; j < x2; j++)
            {
                line.Append(j == x1 ? "* " : "  ");
            }

            line.Append("*");
            yield return line.ToString();
        }
        yield return GetFilledString(baseLen);
    }

    public ValidationResult Validate()
    {
        if (new[] { Base, Left, Right }.Any(x => x <= 1))
        {
            return new ValidationResult("All sides must be positive and greater then 1");
        }
        
        if (Base >= Left + Right
            || Left >= Base + Right
            || Right >= Base + Left)
        {
            return new ValidationResult("The sum of any two sides must be greater than the third");
        }

        return ValidationResult.Success;
    }

    public double Base { get; init; }
    public double Left { get; init; }
    public double Right { get; init; }

    public void Deconstruct(out double Base, out double Left, out double Right)
    {
        Base = this.Base;
        Left = this.Left;
        Right = this.Right;
    }
}