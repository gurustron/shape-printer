// See https://aka.ms/new-console-template for more information

using System.CommandLine;

var rootCommand = new RootCommand();
var fileOption = new Option<string>("--file", "The file path to write shape to")
{
    IsRequired = false,
};
fileOption.AddAlias("-f");
rootCommand.AddGlobalOption(fileOption);

rootCommand.AddCommand(GetSquareCommand());

await rootCommand.InvokeAsync(args);

Console.WriteLine("Hello, World!");


Command GetSquareCommand()
{
    var squareCommand = new Command("square", "Create a square shape");
    var squareSideSizeOption = new Option<int>("--side", "The side size of the square") { IsRequired = true };
    squareSideSizeOption.AddAlias("-s");
    squareCommand.AddOption(squareSideSizeOption);
    squareCommand.SetHandler((squareSide, fileName) =>
    {
        Console.WriteLine($"square: {squareSide}");
        Console.WriteLine(string.IsNullOrEmpty(fileName)
            ? "No file name provided"
            : $"Writing to file: {fileName}");
    }, squareSideSizeOption, fileOption);
    return squareCommand;
}

