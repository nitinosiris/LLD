namespace ParkingLot.ParkingSpot;

public interface IParkingSpot
{
    void ParkVehicle(Vehicle.Vehicle vehicle);
    
    void RemoveVehicle();
    int GetPrice();
}
