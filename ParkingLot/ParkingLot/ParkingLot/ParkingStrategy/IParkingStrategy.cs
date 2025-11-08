namespace ParkingLot.ParkingStrategy;

public interface IParkingStrategy
{
    ParkingSpot.ParkingSpot Find(List<ParkingSpot.ParkingSpot> parkingSpots);
}