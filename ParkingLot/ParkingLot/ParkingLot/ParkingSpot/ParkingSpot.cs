namespace ParkingLot.ParkingSpot
{
    public abstract class ParkingSpot(int price) : IParkingSpot
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        private int Price { get; } = price;
        public bool IsAvailable { get; private set; } = true;
        public Vehicle.Vehicle? Vehicle { get; set; }

        public void ParkVehicle(Vehicle.Vehicle vehicle)
        {
            Vehicle = vehicle;
            IsAvailable = false;
        }

        public void RemoveVehicle()
        {
            Vehicle = null;
            IsAvailable = true;
        }

        public int GetPrice()
        {
            return Price;
        }
    }

    public class TwoWheelerSpot(int price = 20) : ParkingSpot(price);

    public class FourWheelerSpot(int price = 50) : ParkingSpot(price);
}