using HomeWorkNum10.Core.Base;
using HomeWorkNum10.Core.ConsoleReader;
using HomeWorkNum10.Core.Interfaces;

namespace HomeWorkNum10.Core.Calculators;

public class AdditionalCalculator : ACalculator
{
    public AdditionalCalculator(string supportedOperation) : base(supportedOperation,  UserInputType.Double, 2) { }
    
    public override CalculatorResult ProcessOperation(List<dynamic> operators)
    {
        if (operators.Count() < RequiredCountOperators)
            throw new Exception("For process this operation need more operators");
        if (operators.Any(x => x is not double and not int))
            throw new Exception("Wrong type of operators");
        var result = operators[0] + operators[1];
        return new CalculatorResult(result, $"{operators[0]} + {operators[1]} = {result}");
    }
}