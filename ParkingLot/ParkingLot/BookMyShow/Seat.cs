namespace BookMyShow;

// ReSharper disable once ClassNeverInstantiated.Global
public class Seat(int number,  SeatCategory seatCategory)
{
    public int Number { get; private set; } = number;

    public Status Status { get; private set; } = Status.Free;

    public SeatCategory SeatCategory { get; private set; } =  SeatCategory.Silver;
    
}