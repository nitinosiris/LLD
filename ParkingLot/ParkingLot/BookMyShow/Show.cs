namespace BookMyShow;

public class Show(int id, Screen screen, Movie movie, int start)
{
    public int Id { get; private set; } = id;

    public Movie Movie { get; private set; } = movie;

    public Screen Screen { get; private set; } = screen;
    
    public int ShowStartTime  { get; private set; } = start;
    public List<int> BookingSeats { get; } = [];
}
