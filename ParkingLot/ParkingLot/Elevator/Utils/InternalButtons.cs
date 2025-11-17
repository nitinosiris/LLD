using Elevator.ElevatorCar;
using Elevator.Enums;

namespace Elevator.Utils;

public class InternalButtons(int id, InternalButtonsDispatcher dispatcher)
{
    public int ElevatorId { get; private set; } = id;
    private readonly int[] _internalButtons = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    private int? _buttonSelected = null;

    private readonly InternalButtonsDispatcher _dispatcher = dispatcher;

    public bool SelectButton()
    {
        Console.WriteLine("Available Floors: " + string.Join(", ", _internalButtons));
        Console.Write("Select a floor: ");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int selectedFloor) && _internalButtons.Contains(selectedFloor))
        {
            _buttonSelected = selectedFloor;
            Console.WriteLine($"Button Selected: {selectedFloor}");
            
            SubmitRequest((int)_buttonSelected);
            return true;
        }
        Console.WriteLine("Invalid selection. Please choose a valid floor.");
        return false;
    }

    private void SubmitRequest(int floor)
    {
        _dispatcher.SubmitRequest(ElevatorId, floor);
    }
}

public class InternalButtonsDispatcher(ElevatorController elevatorController)
{
    private readonly ElevatorController _elevatorController = elevatorController;

    public void SubmitRequest(int elevatorId, int floor)
    {
        _elevatorController.AcceptInternalRequest(elevatorId, floor);
    }
}


