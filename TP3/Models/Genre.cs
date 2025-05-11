using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFRelations.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // Relation One-to-Many avec Movie
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}