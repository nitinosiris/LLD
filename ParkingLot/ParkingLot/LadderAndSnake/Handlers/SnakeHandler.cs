namespace LadderAndSnake.Handlers;

public class SnakeHandler(Dictionary<int, int> snakePositions) : PositionHandler
{
    private readonly Dictionary<int, int> _snakePositions = snakePositions;

    public override int Handle(int position)
    {
        if (_snakePositions.TryGetValue(position, out var handle))
        {
            Console.WriteLine("Snake got you, go down to " + handle);
            return handle;
        }

        return Next?.Handle(position) ?? position;
    }
}