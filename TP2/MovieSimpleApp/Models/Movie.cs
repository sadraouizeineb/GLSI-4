﻿namespace MovieSimpleApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Guid GenreId { get; set; }//clé etrangere 
        public Genre? Genre { get; set; }
        public Movie()
        {
        }
    }
}
