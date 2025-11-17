using Elevator.Utils;

namespace Elevator.Floor;

public class Floor
{
    private static int _counter = 0;
    public int FloorNumber { get; private set; }

    private ExternalButtons _externalButtons;

    public Floor(ExternalButtonsDispatcher dispatcher)
    {
        FloorNumber = Interlocked.Increment(ref _counter);
        
        _externalButtons = new ExternalButtons(dispatcher);
    }
    
    
}