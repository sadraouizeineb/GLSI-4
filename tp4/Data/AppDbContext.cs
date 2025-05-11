using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tp4.Models;

namespace tp4.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public void SeedData()
        {
            if (!Genres.Any())
            {
                Genres.AddRange(new List<Genre>
                {
                    new Genre { Name = "Action" },
                    new Genre { Name = "Comédie" },
                    new Genre { Name = "Drame" }
                });
                SaveChanges();
            }

            if (!Movies.Any())
            {
                // Vérification que le genre avec ID 1 existe
                var genre = Genres.FirstOrDefault(g => g.Id == 1);
                if (genre != null)
                {
                    Movies.Add(new Movie { Title = "Inception", GenreId = genre.Id });
                    SaveChanges();
                }
            }
        }
    }
}
