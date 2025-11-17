namespace LadderAndSnake.Player;

public class Player(string name, Piece piece)
{
    private static int _counter = 0;

    public string Name { get; private set; } = name;

    public string Id { get; private set; } = GenerateId();
    
    public Piece Piece = piece;
    
    private static string GenerateId()
    {
        var next = Interlocked.Increment(ref _counter);
        return next.ToString();
    }
}
