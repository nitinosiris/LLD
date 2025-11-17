using Elevator.Enums;

namespace Elevator.Utils;

public class Display
{
    public int Floor { get; set; } = 0;
    public Direction Direction { get; set; } = Direction.Idle;

    public void Update(int floor, Direction direction)
    {
        Floor = floor;
        Direction = direction;
    }
}