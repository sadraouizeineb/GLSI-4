using EFRelations.Models;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();//géneration automatique de clé primaire
    [Required(ErrorMessage = "Le nom du film est requis.")]//controle de saisie pour indiquer que le champs est obligatoire
    [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "La date d'ajout est requise.")]
    public DateTime MovieAdded { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Le genre est requis.")]
    public Guid GenreId { get; set; } // Clé étrangère
    public Genre ? Genre { get; set; } // Relation
    public string? PhotoPath { get; set; } // Stocke le chemin de l'image uploadée
}
