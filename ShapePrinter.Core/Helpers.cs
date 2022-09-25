namespace ShapePrinter.Core;

internal static class Helpers
{
    public static string GetFilledString(uint size) => new('*', (int)size);

    public static string GetBorderedString(uint size) => size switch
    {
        0 => string.Empty,
        1 => "*",
        2 => "**",
        _ => $"*{new string(' ', (int)size - 2)}*"
    };
}