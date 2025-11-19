namespace BookMyShow;

public class BookMyShow
{
    private readonly MovieController _movieController = new();
    private readonly TheatreController _theatreController = new();

    public void CreateBooking(string userCity, string movieName)
    {
        // 1. Get movies in city
        var movies = _movieController.GetMoviesInCity(userCity);

        // 2. Find movie by name
        var interestedMovie = movies.FirstOrDefault(m => m.Name == movieName);

        if (interestedMovie == null)
        {
            Console.WriteLine("Movie not found.");
            return;
        }

        // 3. Get all shows in that city for that movie
        var showsTheatreWise = _theatreController.GetAllShows(interestedMovie, userCity);

        // 4. Pick first theatre + first show
        var firstEntry = showsTheatreWise.FirstOrDefault();
        var interestedShow = firstEntry.Value.First();

        // 5. Pick seat
        int seatNumber = 30;
        var bookedSeats = interestedShow.BookingSeats;

        if (!bookedSeats.Contains(seatNumber))
        {
            bookedSeats.Add(seatNumber);

            // Payment first
            var payment = new Payment(200, PaymentStatus.Success);

            // Get seat object
            var myBookedSeat = interestedShow.Screen
                .Seats
                .First(s => s.Number == seatNumber);

            // Create booking
            var booking = new Booking(interestedShow, [myBookedSeat], payment);

            Console.WriteLine("BOOKING SUCCESSFUL");
        }
        else
        {
            Console.WriteLine("Seat already booked. Try again.");
        }
    }

    public void Initialize()
    {
        CreateMovies();
        CreateTheatres();
    }

    // ---------------------------
    // MOVIES
    // ---------------------------
    private void CreateMovies()
    {
        var avengers = new Movie(1, "AVENGERS", 128);
        var baahubali = new Movie(2, "BAAHUBALI", 180);

        _movieController.AddMovie("Bangalore", avengers);
        _movieController.AddMovie("Delhi", avengers);
        _movieController.AddMovie("Bangalore", baahubali);
        _movieController.AddMovie("Delhi", baahubali);
    }

    // ---------------------------
    // THEATRES
    // ---------------------------
    private void CreateTheatres()
    {
        var avengerMovie = _movieController.GetMovieByName("AVENGERS");
        var baahubali = _movieController.GetMovieByName("BAAHUBALI");

        // Theatre 1 - Bangalore
        var inox = new Theatre(
            CreateScreens(),          // screens
            [],         // empty show list
            new Address("Bangalore", "xc", "6346", "Bangalore", "6536", "Ind")  // address
        );

        inox.Shows.Add(CreateShow(1, inox.Screens[0], avengerMovie, 8));
        inox.Shows.Add(CreateShow(2, inox.Screens[0], baahubali, 16));
        _theatreController.AddTheatre(inox, "Bangalore");

        // Theatre 2 - Delhi
        var pvr = new Theatre(
            CreateScreens(),
            [],
            new Address("Delhi", "xc", "6346", "Delhi", "6536", "Ind")
        );

        pvr.Shows.Add(CreateShow(3, pvr.Screens[0], avengerMovie, 13));
        pvr.Shows.Add(CreateShow(4, pvr.Screens[0], baahubali, 20));
        _theatreController.AddTheatre(pvr, "Delhi");
    }

    private List<Screen> CreateScreens()
    {
        return new List<Screen> { new Screen(CreateSeats()) };
    }

    private List<Seat> CreateSeats()
    {
        var seats = new List<Seat>();

        for (int i = 0; i < 40; i++)
            seats.Add(new Seat(i, SeatCategory.Silver));

        for (int i = 40; i < 70; i++)
            seats.Add(new Seat(i, SeatCategory.Gold));

        for (int i = 70; i < 100; i++)
            seats.Add(new Seat(i, SeatCategory.Platinum));

        return seats;
    }

    private Show CreateShow(int showId, Screen screen, Movie movie, int start)
    {
        return new Show(showId, screen, movie, start);
    }
}
