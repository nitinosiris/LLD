using Elevator.Enums;
using Elevator.Utils;

namespace Elevator.ElevatorCar;

public class Elevator
{
    private static int _counter = 0;
    
    public int Id { get; private set; }
    public int CurrentFloor { get; private set; } = 0;

    public Status Status { get; private set; } = Status.Idle;
    public Direction Direction { get; private set; } = Direction.Idle;

    private readonly Display _display;
    private readonly InternalButtons _internalButtons;
    private readonly ElevatorDoor _doors;

    public Elevator(InternalButtonsDispatcher internalButtons)
    {
        Id = Interlocked.Increment(ref _counter);

        _display = new Display();
        _internalButtons = new InternalButtons(Id, internalButtons);
        _doors = new ElevatorDoor();
    }
    
    public void UpdateDisplay(int floor, Direction direction)
    {
        _display.Update(floor, direction);
        Console.WriteLine($"Display Updated : Floor -> {floor}, Direction -> {direction}");
    }

    public void OpenDoor() => _doors.OpenDoor();
    public void CloseDoor() => _doors.CloseDoor();

    public void SetStatus(Status status)
    {
        Status = status;
        Console.WriteLine("Elevator status changed to " + status);
    }

    public void Move(int targetFloor, Direction direction)
    {
        // Elevator does NOT decide anything.
        // Controller tells it what to do, and elevator just updates its state.

        Direction = direction;

        // No logic, just setting values
        CurrentFloor = targetFloor;
    }
}
