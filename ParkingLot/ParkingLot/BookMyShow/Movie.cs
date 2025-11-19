namespace BookMyShow;

public class Movie(int id, string name, int duration)
{
    public int Id { get; private set; }= id;
    public string Name { get; private set; } = name;

    public int Duration { get; private set; } = duration;
}

