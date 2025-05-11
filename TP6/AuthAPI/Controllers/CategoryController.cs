using AuthAPI.Data;
using AuthAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AuthAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize (Roles ="Admin")]
    public class CategorYController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategorYController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]

        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategorie(int id)
        {
            var categorie = _context.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return categorie;
        }

        [HttpPost]
        public ActionResult<Category> PostCategorie(Category categorie)
        {
            _context.Categories.Add(categorie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategorie), new { id = categorie.Id }, categorie);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategorie(int id, Category categorie)
        {
            if (id != categorie.Id)
            {
                return BadRequest();
            }
            _context.Categories.Update(categorie);
/*            _context.Entry(categorie).State = EntityState.Modified;
*/            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategorie(int id)
        {
            var categorie = _context.Categories.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categorie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
