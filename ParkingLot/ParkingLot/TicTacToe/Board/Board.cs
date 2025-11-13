using System;
using TicTacToe.Player;

namespace TicTacToe.Board
{
    public class Board
    {
        public int Size { get; }
        private readonly PlayingPiece?[,] _playingBoard;

        public Board(int size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            _playingBoard = new PlayingPiece?[size, size];
        }

        public LinkedList<KeyValuePair<int, int>> GetFreeCells()
        {
            var list = new LinkedList<KeyValuePair<int, int>>();

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if(_playingBoard[i, j] == null)
                        list.AddLast(new KeyValuePair<int, int>(i, j));
                }
            }

            return list;
        }
        
        public bool AddPiece(int x, int y, PlayingPiece newPiece)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
            {
                Console.WriteLine("Invalid position");
                return false;
            }

            // store as [row, column]
            if (_playingBoard[x, y] != null)
            {
                Console.WriteLine("This piece is already occupied");
                return false;
            }

            _playingBoard[x, y] = newPiece;
            return true;
        }

        public void PrintBoard()
        {
            Console.WriteLine("Current board:");
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    var piece = _playingBoard[row, col];
                    var cellText = piece != null ? piece.PieceType.ToString() : "   ";
                    Console.Write(cellText);
                    if (col < Size - 1) Console.Write("  |  ");
                }
                Console.WriteLine();

                // separator line between rows
                if (row < Size - 1)
                {
                    Console.WriteLine(new string('-', Size * 8 - 3));
                }
            }
        }
        
        public bool CheckWinner(PlayingPiece piece)
        {
            // rows
            for (int r = 0; r < Size; r++)
                if (Enumerable.Range(0, Size).All(c => _playingBoard[r, c] == piece))
                    return true;

            // columns
            for (int c = 0; c < Size; c++)
                if (Enumerable.Range(0, Size).All(r => _playingBoard[r, c] == piece))
                    return true;

            // main diagonal
            if (Enumerable.Range(0, Size).All(i => _playingBoard[i, i] == piece))
                return true;

            // anti diagonal
            if (Enumerable.Range(0, Size).All(i => _playingBoard[i, Size - i - 1] == piece))
                return true;

            return false;
        }
    }
}