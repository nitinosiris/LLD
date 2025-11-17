

using LadderAndSnake.Board;
using LadderAndSnake.Player;

var pieceX = new Piece("X");
var pieceY = new Piece("Y");
var pieceZ = new Piece("Z");

var p1 = new Player("Nitin", pieceX);
var p2 = new Player("Kartik", pieceY);
var p3 = new Player("Pranav", pieceZ);

var snakePositions = new Dictionary<int, int>
{
    { 14, 7 },
    { 28, 10 },
    { 37, 3 },
    { 47, 19 },
    { 75, 32 },
    { 98, 1 }
};

var ladderPositions = new Dictionary<int, int>
{
    { 3, 22 },
    { 5, 8 },
    { 11, 26 },
    { 20, 29 },
    { 27, 56 },
    { 44, 84 }
};

var players = new LinkedList<Player>();
players.AddFirst(p3);
players.AddFirst(p2);
players.AddFirst(p1);

var board = new PlayingBoard(100, snakePositions, ladderPositions);

while (true)
{
    var currentNode = players.First!;
    var currentPlayer = currentNode.Value;

    var dice = new Random().Next(1, 7);

    Console.WriteLine($"Player {currentPlayer.Name} got {dice}");

    var current = currentPlayer.Piece.Position;
    var destination = current + dice;

    Console.WriteLine($"Trying to move from {current} to {destination}");

    if (!board.Validate(destination))
    {
        Console.WriteLine("Move is invalid (beyond board). Turn skipped.\n");
        
        // rotate players
        players.RemoveFirst();
        players.AddLast(currentPlayer);
        continue;
    }

    // Move and detect if the player won
    var won = board.Move(destination, currentPlayer.Piece);

    Console.WriteLine($"Final Position: {currentPlayer.Piece.Position}\n");

    if (won)
    {
        Console.WriteLine($"Player {currentPlayer.Name} WINS!");
        break;
    }

    // Rotate turn
    players.RemoveFirst();
    players.AddLast(currentPlayer);
}