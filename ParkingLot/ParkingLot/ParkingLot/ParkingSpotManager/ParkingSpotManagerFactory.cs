using ParkingLot.Vehicle;

namespace ParkingLot.ParkingSpotManager
{
    public class ParkingSpotManagerFactory
    {
        private static TwoWheelerParkingSpotManager? _twoWheelerInstance;
        private static FourWheelerParkingSpotManager? _fourWheelerInstance;

        public static ParkingSpotManager GetParkingSpotManager(VehicleType vehicleType)
        {
            return vehicleType switch
            {
                VehicleType.TwoWheeler => _twoWheelerInstance ??= new TwoWheelerParkingSpotManager(),
                VehicleType.FourWheeler => _fourWheelerInstance ??= new FourWheelerParkingSpotManager(),
                _ => throw new ArgumentException("Invalid vehicle type.")
            };
        }
    }
}