using Elevator.ElevatorCar;
using Elevator.Utils;

namespace Elevator.Building;

public class Building
{
    // ReSharper disable once CollectionNeverQueried.Local
    private readonly List<Floor.Floor> _floors = [];
    private static readonly ElevatorController  _elevatorController = new();
    private static readonly ExternalButtonsDispatcher  _externalDispatcher = new (_elevatorController);

    public void AddFloor()
    {
        _floors.Add(new Floor.Floor(_externalDispatcher));
    }
}