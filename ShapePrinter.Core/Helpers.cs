namespace ShapePrinter.Core;

internal static class Helpers
{
    public static string GetFilledString(uint size) => string.Join("  ", Enumerable.Repeat("*", (int)size));
    public static string GetBorderedString(uint size) => size switch
    {
        0 => string.Empty,
        1 => "*",
        2 => "**",
        _ => $"*{new string(' ', ((int)size-1) * 2 + (int)size - 2)}*"
    };
}