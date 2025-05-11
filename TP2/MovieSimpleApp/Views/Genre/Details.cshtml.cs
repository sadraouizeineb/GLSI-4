using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieSimpleApp.Models;

namespace MovieSimpleApp.Views_genre
{
    public class DetailsModel : PageModel
    {
        private readonly MovieSimpleApp.Models.ApplicationDbContext _context;

        public DetailsModel(MovieSimpleApp.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            else
            {
                Genre = genre;
            }
            return Page();
        }
    }
}
