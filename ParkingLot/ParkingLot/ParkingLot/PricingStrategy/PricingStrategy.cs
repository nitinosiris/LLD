namespace ParkingLot.PricingStrategy;

public interface IPricingStrategy
{
    int GetPrice(Ticket.Ticket  ticket);
}

public class HourlyPricingStrategy : IPricingStrategy
{
    public int GetPrice(Ticket.Ticket  ticket)
    {
        return (DateTimeOffset.Now.Hour - ticket.EntryTime.Hour) * ticket.ParkingSpot.GetPrice();
    }
}

public class MinutePricingStrategy : IPricingStrategy
{
    public int GetPrice(Ticket.Ticket  ticket)
    {
        return (int)Math.Ceiling((DateTimeOffset.Now - ticket.EntryTime).TotalMinutes) 
               * ticket.ParkingSpot.GetPrice() * 2;
    }
}