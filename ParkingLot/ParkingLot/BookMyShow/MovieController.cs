namespace BookMyShow;

public class MovieController
{
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    private Dictionary<string, List<Movie>> _cityWiseMovies = new();

    private HashSet<Movie> _allMovies = [];

    public void AddMovie(string city, Movie movie)
    {
        if (!_cityWiseMovies.TryGetValue(city, out var movies))
        {
            movies = new List<Movie>();
            _cityWiseMovies[city] = movies;
        }

        movies.Add(movie);
        _allMovies.Add(movie);
    }

    public Movie? GetMovieByName(string movieName)
    {
        return _allMovies.FirstOrDefault(movie => movie.Name == movieName);
    }

    public List<Movie> GetMoviesInCity(string city)
    {
        return _cityWiseMovies[city];
    }

    public void RemoveMovie(Movie movie)
    {
        foreach (var cityWiseMovie in _cityWiseMovies.Where(cityWiseMovie => cityWiseMovie.Value.Contains(movie)))
        {
            _cityWiseMovies.Remove(cityWiseMovie.Key);
        }
        
        _allMovies.Remove(movie);
    }

    public void RemoveMovieInCity(string city, Movie movie)
    {
        _cityWiseMovies[city].Remove(movie);
    }
}