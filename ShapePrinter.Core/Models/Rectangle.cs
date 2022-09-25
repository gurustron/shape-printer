using ShapePrinter.Core.Models.Contract;
using static ShapePrinter.Core.Helpers;

namespace ShapePrinter.Core.Models;

// change to class with validation if we need to disallow empty shapes
public sealed record Rectangle(uint Width, uint Height) : IShape
{
    public IEnumerable<string> GetView()
    {
        if (Width == 0 || Height == 0) yield break;

        yield return GetFilledString(Width);
        if (Height == 1) yield break;

        for (var i = 1; i < Height - 1; i++)
        {
            yield return GetBorderedString(Width);
        }
        
        yield return GetFilledString(Width);
    }
}