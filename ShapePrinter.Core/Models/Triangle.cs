using ShapePrinter.Core.Models.Contract;

namespace ShapePrinter.Core.Models;

public sealed class Triangle : IShape
{
    public Triangle(double @base, double left, double right)
    {
        Base = Math.Round(@base);
        this.Left = left;
        this.Right = right;
    }

    public IEnumerable<string> GetView()
    {
        throw new NotImplementedException();
    }

    public ValidationResult Validate()
    {
        if (new[] { Base, Left, Right }.Any(x => x <= 0))
        {
            return new ValidationResult("All sides must be positive");
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