using AuthAPI.DTOS;
using AuthAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthAPI.Controllers
{
    [Route("api/cat2")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategoriesController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategorieDTO>> GetCategories()
        {
            var categories = _categorieService.Index();
            return Ok(categories);
        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult<CategorieDTO> CreateCategory([FromBody] CategorieDTO categorie)
        {
            if (categorie == null || string.IsNullOrWhiteSpace(categorie.Name))
                return BadRequest("Invalid category data.");

            var created = _categorieService.Create(categorie);
            return CreatedAtAction(nameof(GetCategories), new { id = created.Id }, created);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult<CategorieDTO> UpdateCategory(int id, [FromBody] CategorieDTO categorie)
        {
            var updated = _categorieService.Edit(categorie, id);
            if (updated == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(updated);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categorieService.Delete(id);
            return NoContent();
        }
    }
}
