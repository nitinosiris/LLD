using Elevator.ElevatorCar;
using Elevator.Enums;

namespace Elevator.Utils;

public class ExternalButtons(ExternalButtonsDispatcher dispatcher)
{
    private Direction _direction = Direction.Idle;
    private readonly ExternalButtonsDispatcher _dispatcher = dispatcher;

    public void PressUp(int floor)
    {
        _direction = Direction.Up;
        _dispatcher.SubmitRequest(floor, _direction);
    }

    public void PressDown(int floor)
    {
        _direction = Direction.Down;
        _dispatcher.SubmitRequest(floor, _direction);
    }

}

public class ExternalButtonsDispatcher(ElevatorController elevatorController)
{
    private readonly ElevatorController _elevatorController = elevatorController;
    
    public void SubmitRequest(int floor, Direction direction)
    {
        _elevatorController.AcceptExternalRequest(floor, direction);
    }
}