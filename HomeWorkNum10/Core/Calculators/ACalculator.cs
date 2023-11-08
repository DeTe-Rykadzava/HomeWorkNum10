using HomeWorkNum10.Core.Base;
using HomeWorkNum10.Core.ConsoleReader;
using HomeWorkNum10.Core.Interfaces;

namespace HomeWorkNum10.Core.Calculators;

public abstract class ACalculator : ICalculator
{
    public string SupportedOperation { get; }
    public int RequiredCountOperators { get; }
    public UserInputType NeedOperatorsType { get; }
    
    public ACalculator(string supportedOperation, UserInputType needOperatorsType, int requiredCountOperators)
    {
        SupportedOperation = supportedOperation;
        NeedOperatorsType = needOperatorsType;
        RequiredCountOperators = requiredCountOperators;
    }
    
    public bool CanProcessOperation(string operation)
    {
        return SupportedOperation.Equals(operation);
    }

    public abstract CalculatorResult ProcessOperation(List<dynamic> operators);
}