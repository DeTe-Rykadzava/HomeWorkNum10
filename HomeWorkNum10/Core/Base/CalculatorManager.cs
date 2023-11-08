using System.Text;
using HomeWorkNum10.Core.Calculators;
using HomeWorkNum10.Core.ConsoleReader;
using HomeWorkNum10.Core.Factories;

namespace HomeWorkNum10.Core.Base;

public class CalculatorManager
{
    private List<ACalculator> _calculators = new()
    {
        CalculatorFactory.CreateAdditionalCalculator(),
        CalculatorFactory.CreateSubtractionCalculator(),
        CalculatorFactory.CreateDivisionCalculator(),
        CalculatorFactory.CreateMultiplyCalculator(),
        CalculatorFactory.CreatePOWCalculator(),
        CalculatorFactory.CreateFCalculator()
    };

    public string GetAllAbleCalcOperationsInString()
    {
        return string.Join(" ", _calculators.Select(s => s.SupportedOperation).ToList());
    }

    public List<string> GetAllAbleCalcOperations()
    {
        return _calculators.Select(s => s.SupportedOperation).ToList();
    }

    public bool CanProcessOperation(string operation)
    {
        if (_calculators.Any(x => x.SupportedOperation == operation))
            return true;
        return false;
    }

    public CalculatorResult ProcessOperation(string operation)
    {
        if (_calculators.FirstOrDefault(x => x.SupportedOperation == operation) == null)
            throw new Exception("Cannot process current operation");

        var calc = _calculators.FirstOrDefault(x => x.SupportedOperation == operation)!;

        var parameters = new List<dynamic>();
        for (var i = 0; i < calc.RequiredCountOperators; i++)
        {
            var @operator = ConsoleReaderManager.GetUserInput($"\tInput {i + 1} digit:", calc.NeedOperatorsType);
            parameters.Add(@operator);
        }

        try
        {
            var result = calc.ProcessOperation(parameters);
            return result;
        }
        catch (Exception e)
        {
            using (var sw = new StreamWriter("ErrorLog.txt", true, Encoding.UTF8))
            {
                sw.WriteLine($"[Error]\t{e.Message}");
            }

            return new CalculatorResult(0, e.Message);
        }
    }
}