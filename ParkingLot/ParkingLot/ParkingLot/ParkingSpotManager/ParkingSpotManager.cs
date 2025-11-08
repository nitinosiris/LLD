using ParkingLot.ParkingSpot;
using ParkingLot.ParkingStrategy;

namespace ParkingLot.ParkingSpotManager;

public abstract class ParkingSpotManager(List<ParkingSpot.ParkingSpot> parkingSpots, IParkingStrategy parkingStrategy) : IParkingSpotManager
{
    public ParkingSpot.ParkingSpot FindParkingSpot()
    {
        return parkingStrategy.Find(parkingSpots);
    }

    public void AddParkingSpot(ParkingSpot.ParkingSpot parkingSpot)
    {
        parkingSpots.Add(parkingSpot);
    }

    public void RemoveParkingSpot(ParkingSpot.ParkingSpot parkingSpot)
    {
        parkingSpots.Remove(parkingSpot);
    }

    public void ParkVehicle()
    {
        throw new NotImplementedException();
    }
}

public class TwoWheelerParkingSpotManager() : ParkingSpotManager([new TwoWheelerSpot(), new TwoWheelerSpot()], new NearestToEntranceStrategy()) {}

public class FourWheelerParkingSpotManager() : ParkingSpotManager([new FourWheelerSpot()], new NearestToExitStrategy()) {}