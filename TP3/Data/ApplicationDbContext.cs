using EFRelations.Models;
using Microsoft.EntityFrameworkCore;

namespace EFRelations.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            string GenreJSon = System.IO.File.ReadAllText("Genres.Json");
            List<Genre>? genres = System.Text.Json.
            JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
          
            foreach (Genre c in genres)
                modelBuilder.Entity<Genre>()
                 .HasData(c);
        }
    }
}