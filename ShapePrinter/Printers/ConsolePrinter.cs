using ShapePrinter.Core.Models.Contract;

namespace ShapePrinter.Printers;

public class ConsolePrinter : IPrinter
{
    public Task PrintAsync(IShape shape)
    {
        foreach (var str in shape.GetView())
        {
            Console.WriteLine(str);
        }
        
        return Task.CompletedTask;
    }
}
