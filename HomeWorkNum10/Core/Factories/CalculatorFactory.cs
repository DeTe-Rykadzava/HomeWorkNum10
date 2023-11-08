using HomeWorkNum10.Core.Calculators;

namespace HomeWorkNum10.Core.Factories;

public class CalculatorFactory
{
    public static ACalculator CreateAdditionalCalculator()
    {
        return new AdditionalCalculator("+");
    }

    public static ACalculator CreateSubtractionCalculator()
    {
        return new SubtractionCalculator("-");
    }

    public static ACalculator CreateMultiplyCalculator()
    {
        return new MultiplyCalculator("*");
    }

    public static ACalculator CreateDivisionCalculator()
    {
        return new DivisionCalculator("/");
    }

    public static ACalculator CreatePOWCalculator()
    {
        return new POWCalculator("POW");
    }

    public static ACalculator CreateFCalculator()
    {
        return new FCalculator("F");
    }
}