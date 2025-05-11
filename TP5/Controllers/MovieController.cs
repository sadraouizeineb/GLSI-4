using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using TP5.Data;
using TP5.Models;

namespace TP5.Controllers
{
  
public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MovieController( ApplicationDbContext context)
        {
            
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
    }

}

