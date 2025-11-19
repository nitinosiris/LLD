namespace BookMyShow;

public class TheatreController
{
    // ReSharper disable once CollectionNeverUpdated.Local
    private readonly Dictionary<string, List<Theatre>> _theatresInCity = [];
    // ReSharper disable once CollectionNeverQueried.Local
    private readonly HashSet<Theatre> _allTheatres = [];
    
    public void AddTheatre(Theatre theatre, string city)
    {
        _allTheatres.Add(theatre);

        if (!_theatresInCity.TryGetValue(city, out var theatres))
        {
            theatres = [];
            _theatresInCity[city] = theatres;
        }

        theatres.Add(theatre);
    }


    public Dictionary<Theatre, List<Show>> GetAllShows(Movie movie, string city)
    {
        var theatreVsShows = new Dictionary<Theatre, List<Show>>();

        if (!_theatresInCity.TryGetValue(city, out var theatres))
            return theatreVsShows;

        foreach (var theatre in theatres)
        {
            // fetch shows of this theatre
            var shows = theatre.Shows;

            // filter shows by movie
            var givenMovieShows = shows
                .Where(show => show.Movie.Id == movie.Id)
                .ToList();

            if (givenMovieShows.Count > 0)
            {
                theatreVsShows[theatre] = givenMovieShows;
            }
        }

        return theatreVsShows;
    }
}