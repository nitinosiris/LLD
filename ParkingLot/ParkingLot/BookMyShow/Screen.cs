namespace BookMyShow;

public class Screen(List<Seat> seats)
{
    private string _id = Guid.NewGuid().ToString();

    public List<Seat> Seats { get; private set; } = seats;

}