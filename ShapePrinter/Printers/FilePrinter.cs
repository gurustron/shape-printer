using ShapePrinter.Core.Models.Contract;

namespace ShapePrinter.Printers;

public class FilePrinter : IPrinter
{
    public FilePrinter(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }

    public async Task PrintAsync(IShape shape) => await File.WriteAllLinesAsync(FileName, shape.GetView());
}