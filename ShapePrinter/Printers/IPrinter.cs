using ShapePrinter.Core.Models.Contract;

namespace ShapePrinter.Printers;

public interface IPrinter
{
    Task PrintAsync(IShape shape);
}