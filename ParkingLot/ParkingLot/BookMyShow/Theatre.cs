namespace BookMyShow;

public class Theatre(List<Screen> screens, List<Show> shows, Address address)
{
    private string _id = Guid.NewGuid().ToString();
    
    public int TheatreId { get; private set; }
    
    public Address Address { get; private set; } = address;
    
    public List<Screen> Screens { get; private set; } = screens;

    public List<Show> Shows { get; private set; } = shows;
}
