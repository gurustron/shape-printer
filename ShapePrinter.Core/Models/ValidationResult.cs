namespace ShapePrinter.Core.Models;

public sealed class ValidationResult
{
    public static readonly ValidationResult Success = new();

    public ValidationResult(string? error)
    {
        IsValid = false;
        Error = error;
    }

    private ValidationResult()
    {
        IsValid = true;
    }

    public bool IsValid { get; init; }
    public string? Error { get; init; }

    public void Deconstruct(out bool isValid, out string? error)
    {
        isValid = IsValid;
        error = Error;
    }
}
