using EFRelations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace EFRelations.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    var fileName = Path.GetFileName(photo.FileName);
                    var filePath = Path.Combine("wwwroot/images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }

                    movie.PhotoPath = "images/" + fileName;
                }

                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "Id", "Name", movie.GenreId);
            return View(movie);
        }
    }
}
