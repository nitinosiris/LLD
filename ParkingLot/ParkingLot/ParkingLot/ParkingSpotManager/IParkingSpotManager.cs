namespace ParkingLot.ParkingSpotManager;

public interface IParkingSpotManager
{
    ParkingSpot.ParkingSpot FindParkingSpot();
    
    void AddParkingSpot(ParkingSpot.ParkingSpot parkingSpot);
    
    void RemoveParkingSpot(ParkingSpot.ParkingSpot parkingSpot);

    void ParkVehicle();
}