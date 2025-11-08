namespace ParkingLot.ParkingStrategy;

public class DefaultParkingStrategy : IParkingStrategy
{
    public ParkingSpot.ParkingSpot Find(List<ParkingSpot.ParkingSpot> parkingSpots)
    {
        return parkingSpots.FirstOrDefault(s => s.IsAvailable) ?? throw new InvalidOperationException();
    }
}

public class NearestToEntranceStrategy : IParkingStrategy
{
    public ParkingSpot.ParkingSpot Find(List<ParkingSpot.ParkingSpot> parkingSpots)
    {
        return parkingSpots
            .OrderBy<ParkingSpot.ParkingSpot, object>(s => s.Id) // Assuming lower ID means closer to entrance (you can replace with distance)
            .FirstOrDefault(s => s.IsAvailable) ?? throw new InvalidOperationException();
    }
}

public class NearestToExitStrategy : IParkingStrategy
{
    public ParkingSpot.ParkingSpot Find(List<ParkingSpot.ParkingSpot> parkingSpots)
    {
        return parkingSpots
            .OrderByDescending(s => s.Id) // Assuming higher ID means closer to exit
            .FirstOrDefault(s => s.IsAvailable) ?? throw new InvalidOperationException();
    }
}