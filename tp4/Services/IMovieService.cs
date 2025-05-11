using tp4.Models;
using System.Collections.Generic;

namespace tp4.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetMoviesByGenreId(int genreId);
        // Service to get movies by genre name
        IEnumerable<Movie> GetMoviesByGenreName(string genreName);

        // Service to list all movies ordered by title in ascending order
        IEnumerable<Movie> GetMoviesOrderedByTitleAsc();
        IEnumerable<Movie> GetMoviesOrderedByTitleDesc();

        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
