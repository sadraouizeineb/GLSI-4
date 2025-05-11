using AuthAPI.Data;
using AuthAPI.DTOS;
using AuthAPI.IServices;
using AuthAPI.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AuthAPI.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategorieService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategorieDTO Create(CategorieDTO categorie)
        {
            var cat = _mapper.Map<Category>(categorie);// Transforme le DTO en entité
            _context.Categories.Add(cat);
            _context.SaveChanges();
            return categorie;                           // Retourne le DTO original
        }

        public CategorieDTO Edit(CategorieDTO c, int id)
        {
            var catInDb = _context.Categories.FirstOrDefault(cat => cat.Id == id);
            if (catInDb == null) return null;

            catInDb.Name = c.Name;
            _context.SaveChanges();

            return _mapper.Map<CategorieDTO>(catInDb);
        }

        public IEnumerable<CategorieDTO> Index()
        {
            var categories = _context.Categories.ToList();
            return _mapper.Map<List<CategorieDTO>>(categories);// Convertit en liste de DTOs
        }

        public void Delete(int id)
        {
            var catInDb = _context.Categories.Find(id);
            if (catInDb == null) return;

            _context.Categories.Remove(catInDb);
            _context.SaveChanges();
        }
    }
}
