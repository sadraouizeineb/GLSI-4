using Microsoft.AspNetCore.Mvc;
using tp4.Models;
using tp4.Services;

namespace tp4.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        public IActionResult ByGenre(int id)
        {
            var movies = _movieService.GetMoviesByGenreId(id);
            return View("Index", movies);
        }
        // Action to get movies by genre name
        public IActionResult ByGenreName(string genreName)
        {
            var movies = _movieService.GetMoviesByGenreName(genreName);
            return View("Index", movies);
        }

        // Action to get movies ordered by title in ascending order
        public IActionResult OrderedByTitle()
        {
            var movies = _movieService.GetMoviesOrderedByTitleAsc();
            return View("Index", movies); 
        }
        // Action to get movies ordered by title in ascending order
        public IActionResult OrderedByTitledesc()
        {
            var movies = _movieService.GetMoviesOrderedByTitleDesc();
            return View("Index", movies);
        }
        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.UpdateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}
