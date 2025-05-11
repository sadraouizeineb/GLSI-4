using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieSimpleApp.Models;

namespace MovieSimpleApp.Controllers
{
    public class MoviesController : Controller

    {
        private readonly ApplicationDbContext _context;
        //private readonly ApplicationDbContext _db;

        //public MovieController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}
        //    public IActionResult Index()
        //    {
        //        var movies = _db.Movies.ToList();
        //        return View(movies);
        //    }
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Create(Movie movie)
        //    {
        //        _db.Movies.Add(movie);
        //        _db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    public IActionResult Edit(int id)
        //    {
        //        var movie = _db.Movies.Find(id);
        //        if (movie == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(movie);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Edit(Movie movie)
        //    {
        //        _db.Movies.Update(movie);
        //        _db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    public IActionResult Delete(int id)
        //    {
        //        var movie = _db.Movies.Find(id);
        //        return View(movie);
        //    }

        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult DeleteConfirmed(int id)
        //    {
        //        var movie = _db.Movies.Find(id);
        //        if (movie != null)
        //        {
        //            _db.Movies.Remove(movie);
        //            _db.SaveChanges();
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }

        //
        //
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return movie == null ? NotFound() : View(movie);
        }

        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            return movie == null ? NotFound() : View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

