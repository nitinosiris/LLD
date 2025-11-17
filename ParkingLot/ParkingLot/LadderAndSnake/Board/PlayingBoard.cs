using LadderAndSnake.Handlers;
using LadderAndSnake.Player;

namespace LadderAndSnake.Board;

public class PlayingBoard
{
    private readonly int _size;
    
    private readonly PositionHandler _handlerChain;

    public PlayingBoard(int size, Dictionary<int,int> snakes,
        Dictionary<int,int> ladders)
    {
        _size = size;
        
        var snakeHandler = new SnakeHandler(snakes);
        var ladderHandler = new LadderHandler(ladders);
        var defaultHandler = new DefaultHandler();
        
        snakeHandler.SetNext(ladderHandler);
        ladderHandler.SetNext(defaultHandler);

        _handlerChain = snakeHandler;
    }

    public bool Move(int destination, Piece piece)
    {
        // check for snake or ladder 
        var finalPosition = _handlerChain.Handle(destination);
        
        piece.Position = finalPosition;

        if (finalPosition != _size) 
            return false;
        
        Console.WriteLine($"Piece {piece.Name} won.");
        return true;

    }

    public bool Validate(int destination)
    {
        return destination <= _size;
    }
}