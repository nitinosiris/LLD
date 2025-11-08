namespace ParkingLot.Ticket;

public class Ticket(ParkingSpot.ParkingSpot parkingSpot)
{
    public DateTimeOffset EntryTime = DateTimeOffset.Now;
    public readonly ParkingSpot.ParkingSpot ParkingSpot = parkingSpot;
}