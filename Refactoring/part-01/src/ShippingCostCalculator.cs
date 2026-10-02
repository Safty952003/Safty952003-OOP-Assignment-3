namespace RefactoringLab;

public class ShippingCostCalculator
{
    private readonly IShippingCarrier _carrier;

    public ShippingCostCalculator(IShippingCarrier carrier)
    {
        _carrier = carrier;
    }

    public decimal Calculate(decimal weightKg)
    {
        return _carrier.CalculateCost(weightKg);
    }
}
public interface IShippingCarrier
{
    decimal CalculateCost(decimal weightKg);
}

public class AramexCarrier : IShippingCarrier
{
    public decimal CalculateCost(decimal weightKg)
    {
        return weightKg * 12m;
    }
}

public class FedExCarrier : IShippingCarrier
{
    public decimal CalculateCost(decimal weightKg)
    {
        return weightKg * 15m;
    }
}

public class DHLCarrier : IShippingCarrier
{
    public decimal CalculateCost(decimal weightKg)
    {
        return weightKg * 18m;
    }
}