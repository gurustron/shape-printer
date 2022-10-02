// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using ShapePrinter.Core.Models;
using ShapePrinter.Core.Models.Contract;
using ShapePrinter.Printers;

ConsolePrinter consolePrinter = new ConsolePrinter();
for (uint i = 1 ; i < 7; i++)
{
    await consolePrinter.PrintAsync(new Circle(i));

    Console.WriteLine(new string('-', 20));
}
            
        // double thickness = 0.4;
        // ConsoleColor BorderColor = ConsoleColor.Yellow;
        // Console.ForegroundColor = BorderColor;
        // char symbol = '*';
        //
        //
        // for (int i = 1; i < 7; i++)
        // {
        //     Console.WriteLine();
        //     double radius = i;
        //     double rIn =radius- thickness, rOut = radius + thickness;
        //
        //     for (double y = radius; y >= -radius; --y)
        //     {
        //         for (double x = -radius; x < rOut; x += 0.5)
        //         {
        //             double value = x * x + y * y;
        //             if (value >= rIn * rIn && value <= rOut * rOut)
        //             {
        //                 Console.Write(symbol);
        //             }
        //             else
        //             {
        //                 Console.Write(" ");
        //             }
        //         }
        //         Console.WriteLine();
        //     }
        //
        // }
        //
        //
        // Console.ReadKey();
var rootCommand = new RootCommand();
var fileOption = new Option<FileInfo?>("--file", "The file path to write shape to")
{
    IsRequired = false,
};
fileOption.AddAlias("-f");
rootCommand.AddGlobalOption(fileOption);

rootCommand.AddCommand(GetSquareCommand());
rootCommand.AddCommand(GetRectangleCommand());
rootCommand.AddCommand(GetCircleCommand());

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
    
    var heightSizeOption = new Option<uint>("--height", "The height of rectangle") { IsRequired = true };
    heightSizeOption.AddAlias("-h");
    
    command.AddOption(widthSizeOption);
    command.AddOption(heightSizeOption);
    command.SetHandler(
        (width, height, fileName) => HandleShape(new Rectangle(width, height), fileName),
        widthSizeOption,
        heightSizeOption,
        fileOption);
    return command;
}

Command GetCircleCommand()
{
    var command = new Command("circle", "Create a circle shape");
    var radiusOption = new Option<uint>("--radius", "The radius of the circle") { IsRequired = true };
    radiusOption.AddAlias("-r");
    command.AddOption(radiusOption);
    command.SetHandler(
        (radius, fileName) => HandleShape(new Circle(radius), fileName),
        radiusOption,
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




