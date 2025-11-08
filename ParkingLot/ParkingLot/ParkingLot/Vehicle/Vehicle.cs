namespace ParkingLot.Vehicle
{
    public abstract class Vehicle(VehicleType vehicleType)
    {
        public int Id { get; } = new Random().Next();
        public VehicleType VehicleType { get; } = vehicleType;
    }

    public class TwoWheelerVehicle() : Vehicle(VehicleType.TwoWheeler);

    public class FourWheelerVehicle() : Vehicle(VehicleType.FourWheeler);
}