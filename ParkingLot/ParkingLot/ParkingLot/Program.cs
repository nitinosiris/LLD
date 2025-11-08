using ParkingLot.CostComputation;
using ParkingLot.EntranceGate;
using ParkingLot.ExitGate;
using ParkingLot.Vehicle;

var entranceGate = new EntranceGate();

var vehicle = new TwoWheelerVehicle();

var spot = entranceGate.FindParkingSpot(vehicle.VehicleType);

if (spot == null)
{
    throw new Exception("No Parking Spot found");
}

entranceGate.BookParkingSpot(spot, vehicle);

var ticket = entranceGate.GenerateTicket(spot);

var exitGate = new ExitGate(new CostComputationFactory());

var price = exitGate.PriceCalculation(ticket);
Console.WriteLine(price);



