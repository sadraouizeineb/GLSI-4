using Microsoft.EntityFrameworkCore;
using tp4.Data;
using tp4.Models;
using System.Collections.Generic;
using System.Linq;

namespace tp4.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList();
        }


        public Movie GetMovieById(int id)
        {
            return _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
        }

        
        // Service to get movies by genre ID
        public IEnumerable<Movie> GetMoviesByGenreId(int genreId)
        {
            return _context.Movies
                           .Where(m => m.GenreId == genreId)
                           .Include(m => m.Genre)
                           .ToList();
        }
        // Service to list all movies associated with a specific genre
        public IEnumerable<Movie> GetMoviesByGenreName(string genreName)
        {
            return _context.Movies
                           .Where(m => m.Genre.Name == genreName)
                           .Include(m => m.Genre)
                           .ToList();
        }

        // Service to list all movies ordered in ascending order
        public IEnumerable<Movie> GetMoviesOrderedByTitleAsc()
        {
            return _context.Movies
                           .OrderBy(m => m.Title)
                           .Include(m => m.Genre)
                           .ToList();
        }

        public IEnumerable<Movie> GetMoviesOrderedByTitleDesc()
        {
            return _context.Movies
                           .OrderByDescending(m => m.Title)
                           .Include(m => m.Genre)
                           .ToList();
        }


        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
