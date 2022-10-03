using ShapePrinter.Core.Models.Contract;
using static ShapePrinter.Core.Helpers;

namespace ShapePrinter.Core.Models;

// change to class with validation if we need to disallow empty shapes
public sealed record Square(uint Side) : IShape
{
    public IEnumerable<string> GetView()
    {
        if (Side == 0)
        {
            yield break;
        }

        yield return GetFilledString(Side);

        if (Side == 1)
        {
            yield break;
        }

        for (var i = 1; i < Side - 1; i++)
        {
            yield return GetBorderedString(Side);
        }

        yield return GetFilledString(Side);
    }

    public ValidationResult Validate() => ValidationResult.Success;
}