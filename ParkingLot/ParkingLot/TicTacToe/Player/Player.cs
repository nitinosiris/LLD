namespace TicTacToe.Player;

public class Player(String name, PlayingPiece playingPiece)
{
    public string Name { get; set; } = name;
    public PlayingPiece PlayingPiece { get; set; } = playingPiece;
}