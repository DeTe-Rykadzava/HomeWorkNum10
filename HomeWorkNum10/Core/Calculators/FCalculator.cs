using HomeWorkNum10.Core.Base;
using HomeWorkNum10.Core.ConsoleReader;
using HomeWorkNum10.Core.Interfaces;

namespace HomeWorkNum10.Core.Calculators;

public class FCalculator : ACalculator
{
    public FCalculator(string supportedOperation) : base(supportedOperation, UserInputType.Int, 1) { }

    public override CalculatorResult ProcessOperation(List<dynamic> operators)
    {
        if (operators.Count() < RequiredCountOperators)
            throw new Exception("For process this operation need more operators");
        if (operators.Any(x => x is not int))
            throw new Exception("Wrong type of operators");
        if (operators[0] < 0)
            throw new Exception("Value cannot be less than zero");

        var result = GetFactorial((uint)operators[0]);
        return new CalculatorResult(result, $"{operators[0]}! = {result}");
    }

    private uint GetFactorial(uint num)
    {
        if (num == 1) return num;

        return num * GetFactorial(--num);
    }
}