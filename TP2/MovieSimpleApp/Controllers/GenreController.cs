using Microsoft.AspNetCore.Mvc;
using MovieSimpleApp.Models;

namespace MovieSimpleApp.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _context;//_db

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }
      
        // Afficher la liste des genres
        public IActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }

        // Détails d'un genre
        public IActionResult Details(Guid id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null)
                return NotFound();
            return View(genre);
        }

        // Formulaire de création
        public IActionResult Create()
        {
            return View();
        }

        // Ajouter un genre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Genre genre)
        {
            //generation d'un Guid
                genre.Id = Guid.NewGuid();
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }

        // Formulaire de modification
        public IActionResult Edit(Guid id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null)
                return NotFound();
            return View(genre);
        }

        // Modifier un genre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            //if (genre == null || genre.Id == Guid.Empty)
            //{
            //    return NotFound();
            //}
                _context.Genres.Update(genre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
          }
        
        // Supprimer un genre (confirmation)
        public IActionResult Delete(Guid id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null)
                return NotFound();
            return View(genre);
        }

        // Supprimer un genre (action)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var genre = _context.Genres.Find(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

