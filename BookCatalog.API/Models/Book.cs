using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalog.Models;

public class Book
{
    [Key]
    public int BookId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public DateTime ReleaseDate { get; set; } = DateTime.Now;

    [ForeignKey("Genre")]
    public int GenreId { get; set; }

    [Required]
    public Genre Genre { get; set; } = null!;

    [ForeignKey("Author")]
    public int AuthorId { get; set; }

    [Required]
    public Author Author { get; set; } = null!;

    public List<Order> Orders { get; set; } = new List<Order>();
}