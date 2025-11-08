using ParkingLot.Vehicle;

namespace ParkingLot.CostComputation;

public class CostComputationFactory
{
    private TwoWheelerCostComputation? _twoWheelerCostComputation;
    private FourWheelerCostComputation? _fourWheelerCostComputation;

    public CostComputation GetCostComputation(VehicleType vehicleType)
    {
        if (vehicleType == VehicleType.TwoWheeler)
        {
            _twoWheelerCostComputation ??= new TwoWheelerCostComputation();
            return _twoWheelerCostComputation;
        }
        else
        {
            _fourWheelerCostComputation ??= new FourWheelerCostComputation();
            return _fourWheelerCostComputation;
        }
    }
}