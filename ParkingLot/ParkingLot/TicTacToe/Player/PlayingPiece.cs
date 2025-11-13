namespace TicTacToe.Player;

public class PlayingPiece(PieceType pieceType)
{
    public PieceType PieceType = pieceType;
}

public class PlayingPieceX() : PlayingPiece (PieceType.X) {}

public class PlayingPieceO() : PlayingPiece (PieceType.O) {}