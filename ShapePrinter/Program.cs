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
rootCommand.AddCommand(GetRectangleCommand());

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


Command GetRectangleCommand()
{
    var command = new Command("rectangle", "Create a rectangle shape");
    
    var widthSizeOption = new Option<uint>("--width", "The width of rectangle") { IsRequired = true };
    widthSizeOption.AddAlias("-w");
    
    var heightSizeOption = new Option<uint>("--width", "The width of rectangle") { IsRequired = true };
    heightSizeOption.AddAlias("-w");
    
    command.AddOption(widthSizeOption);
    command.AddOption(heightSizeOption);
    command.SetHandler(
        (width, height, fileName) => HandleShape(new Rectangle(width, height), fileName),
        widthSizeOption,
        heightSizeOption,
        fileOption);
    return command;
}

async Task HandleShape(IShape shape, FileInfo? fileInfo)
{
    IPrinter printer = fileInfo == null
        ? new ConsolePrinter()
        : new FilePrinter(fileInfo.FullName);

    await printer.PrintAsync(shape);
}




