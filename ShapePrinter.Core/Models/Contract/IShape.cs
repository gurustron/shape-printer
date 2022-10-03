namespace ShapePrinter.Core.Models.Contract;

public interface IShape
{
    // potentially we can move this to a printer/serializator (shape -> serialization -> printer)
    // but for current task it's good enough
    IEnumerable<string> GetView();
    
    ValidationResult Validate();
}