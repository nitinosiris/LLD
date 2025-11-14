using TicTacToe.Player;

namespace TicTacToe
{
    public class TicTacToe
    {
        private LinkedList<Player.Player> _players;
        private Board.Board _board;

        public TicTacToe()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _players = new LinkedList<Player.Player>();
            
            var crossPieceX = new PlayingPieceX();
            var player1 = new Player.Player("Player 1", crossPieceX);
            
            var crossPieceO = new PlayingPieceO();
            var player2 = new Player.Player("Player 2", crossPieceO);

            _players.AddLast(player1);
            _players.AddLast(player2);

            _board = new Board.Board(3);
        }

        public void StartGame()
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                _board.PrintBoard();
                Console.WriteLine();

                // tie condition
                if (_board.GetFreeCells().Count == 0)
                {
                    Console.WriteLine("No winner! It's a tie.");
                    break;
                }

                var currPlayer = _players.First!.Value;
                Console.WriteLine($"Enter position for {currPlayer.Name} ({currPlayer.PlayingPiece}) in format row,col:");
                
                var input = Console.ReadLine();

                if (!TryParseCoordinates(input, out int x, out int y))
                {
                    Console.WriteLine("Invalid input! Please enter format: row,col");
                    continue;
                }

                if (!_board.AddPiece(x, y, currPlayer.PlayingPiece))
                {
                    continue;
                }

                // Check winner
                if (_board.CheckWinner(currPlayer.PlayingPiece))
                {
                    _board.PrintBoard();
                    Console.WriteLine($"{currPlayer.Name} wins!");
                    gameRunning = false;
                    continue;
                }

                // rotate players
                _players.RemoveFirst();
                _players.AddLast(currPlayer);
            }
        }

        private static bool TryParseCoordinates(string? input, out int x, out int y)
        {
            x = y = -1;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            var parts = input.Split(',');

            if (parts.Length != 2)
                return false;

            bool okX = int.TryParse(parts[0].Trim(), out x);
            bool okY = int.TryParse(parts[1].Trim(), out y);

            return okX && okY;
        }
    }
}
