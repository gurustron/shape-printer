// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using ShapePrinter.Core.Models;
using ShapePrinter.Core.Models.Contract;
using ShapePrinter.Printers;

var rootCommand = new RootCommand();
var fileOption = new Option<FileInfo?>("--file", "The file path to write shape to")
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
    var squareSideSizeOption = new Option<uint>("--side", "The side size of the square") { IsRequired = true };
    squareSideSizeOption.AddAlias("-s");
    squareCommand.AddOption(squareSideSizeOption);
    squareCommand.SetHandler(
        (squareSide, fileName) => HandleShape(new Square(squareSide), fileName),
        squareSideSizeOption, 
        fileOption);
    return squareCommand;
}

async Task HandleShape(IShape shape, FileInfo? fileInfo)
{
    IPrinter printer = fileInfo == null
        ? new ConsolePrinter()
        : new FilePrinter(fileInfo.FullName);

    await printer.PrintAsync(shape);
}




