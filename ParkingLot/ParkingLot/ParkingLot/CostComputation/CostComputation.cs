using ParkingLot.PricingStrategy;

namespace ParkingLot.CostComputation;

public abstract class CostComputation(IPricingStrategy pricingStrategy)
{
    private readonly IPricingStrategy _pricingStrategy = pricingStrategy;

    public int GetPrice(Ticket.Ticket ticket)
    {
        return _pricingStrategy.GetPrice(ticket);
    }
}

public class TwoWheelerCostComputation() : CostComputation(new MinutePricingStrategy());

public class FourWheelerCostComputation()  : CostComputation(new HourlyPricingStrategy());