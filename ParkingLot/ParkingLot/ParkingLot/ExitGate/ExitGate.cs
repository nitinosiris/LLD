using ParkingLot.CostComputation;

namespace ParkingLot.ExitGate;

public class ExitGate(CostComputationFactory costComputationFactory)
{
    public int PriceCalculation(Ticket.Ticket ticket)
    {
        if (ticket.ParkingSpot.Vehicle != null)
            return costComputationFactory.GetCostComputation(ticket.ParkingSpot.Vehicle.VehicleType).GetPrice(ticket);
        return 0;
    }

    public void FreeParking(Ticket.Ticket ticket)
    {
        if (ticket.ParkingSpot.Vehicle != null)
            ticket.ParkingSpot.RemoveVehicle();
    }
}