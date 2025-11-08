using ParkingLot.ParkingSpotManager;
using ParkingLot.Vehicle;

namespace ParkingLot.EntranceGate
{
    public class EntranceGate
    {
        private ParkingSpotManagerFactory _parkingSpotManagerFactory = new();

        public ParkingSpot.ParkingSpot? FindParkingSpot(VehicleType vehicleType)
        {
            var manager = ParkingSpotManagerFactory.GetParkingSpotManager(vehicleType);
            return manager.FindParkingSpot();
        }

        public void BookParkingSpot(ParkingSpot.ParkingSpot parkingSpot, Vehicle.Vehicle vehicle)
        {
            parkingSpot.ParkVehicle(vehicle);
            Console.WriteLine("Booked ParkingSpot with ID " + parkingSpot.Id);
        }

        public Ticket.Ticket GenerateTicket(ParkingSpot.ParkingSpot parkingSpot)
        {
            return new Ticket.Ticket(parkingSpot);
        }
    }
}