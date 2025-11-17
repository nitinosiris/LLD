using Elevator.Enums;

namespace Elevator.ElevatorCar;

public class ElevatorController
{
    // ReSharper disable once CollectionNeverUpdated.Local
    private readonly List<Elevator> _elevators = [];

    public void AcceptInternalRequest(int elevatorId, int floor)
    {
        // decide direction
        // change status
        _elevators.Find(x => x.Id == elevatorId)?.Move(floor, Direction.Idle);
    }
    
    public void AcceptExternalRequest(int floor, Direction direction)
    {
        // decide direction
        // change status
        // _elevators.Find(x => x.Id == elevatorId)?.Move(floor, Direction.Idle);
    }
}