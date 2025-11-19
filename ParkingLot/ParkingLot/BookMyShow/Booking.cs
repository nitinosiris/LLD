namespace BookMyShow;

public class Booking(Show show, List<Seat> bookedSeats, Payment payment)
{
    public Show Show { get; private set; } = show;

    public List<Seat> BookedSeats { get; private set; } = bookedSeats;

    public Payment Payment { get; private set; } = payment;
}