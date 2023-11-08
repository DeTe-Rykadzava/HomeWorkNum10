using HomeWorkNum10.Core.Base;
using HomeWorkNum10.Core.ConsoleReader;

namespace HomeWorkNum10.Core.Interfaces;

public interface ICalculator
{
    public string SupportedOperation { get; }
    public int RequiredCountOperators { get; }
    public UserInputType NeedOperatorsType { get; }

    public bool CanProcessOperation(string operation);

    public CalculatorResult ProcessOperation(List<dynamic> operators);
}