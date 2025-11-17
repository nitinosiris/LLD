namespace LadderAndSnake.Handlers;

public abstract class PositionHandler
{
    protected PositionHandler? Next;

    public PositionHandler SetNext(PositionHandler next)
    {
        Next = next;
        return next;
    }

    public abstract int Handle(int position);
}


public class DefaultHandler() : PositionHandler
{
    public override int Handle(int position)
    {
        return Next?.Handle(position) ?? position;
    }
}
