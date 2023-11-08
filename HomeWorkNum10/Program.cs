// See https://aka.ms/new-console-template for more information

using HomeWorkNum10.Core.Base;
using HomeWorkNum10.Core.ConsoleReader;

var calcManager = new CalculatorManager();
while (true)
{
    Console.WriteLine("Calculator v4.0 =)");
    Console.WriteLine("=============================================================");
    var operation = "";
    while (true)
    {
        Console.Write($"\tSelect Operation ({calcManager.GetAllAbleCalcOperationsInString()}): ");
        var userInput = ConsoleReaderManager.GetUserInput(UserInputType.String);
        if (!calcManager.CanProcessOperation(userInput.ToString()!))
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("You input wrong operation name. Please try again!");
            Console.ResetColor();
            continue;
        }

        operation = userInput.ToString()!;
        break;
    }

    Console.WriteLine("=============================================================");
    var result = calcManager.ProcessOperation(operation);
    Console.WriteLine("=============================================================");
    Console.WriteLine("\t" + result.StringResult);
    Console.WriteLine("=============================================================");
    Console.WriteLine("\nPress any key for retry or press {Space} for exit...");
    var inputKey = Console.ReadKey();
    if (inputKey.Key == ConsoleKey.Spacebar)
        break;
}