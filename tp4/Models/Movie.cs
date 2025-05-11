using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tp4.Models
{
    public class Movie
    { public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }
    }
}
