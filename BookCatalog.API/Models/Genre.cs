

using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Models;

public class Genre
{
    [Key]
    public int GenreId { get; set; }

    [Required]

    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]

    public string? Description { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
}