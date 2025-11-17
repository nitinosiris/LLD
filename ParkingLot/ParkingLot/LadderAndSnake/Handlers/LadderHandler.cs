namespace LadderAndSnake.Handlers;

public class LadderHandler(Dictionary<int, int> ladderPositions) : PositionHandler
{
    private readonly Dictionary<int, int> _ladderPositions = ladderPositions;

    public override int Handle(int position)
    {
        if (_ladderPositions.TryGetValue(position, out var handle))
        {
            Console.WriteLine("You got ladder, go up to " + handle);
            return handle;
        }

        return Next?.Handle(position) ?? position;
    }
}