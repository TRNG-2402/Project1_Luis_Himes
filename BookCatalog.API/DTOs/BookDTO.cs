

using System.ComponentModel.DataAnnotations;

namespace BookCatalog.DTOs;

public class BookDTO
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int GenreId { get; set; }

    public int AuthorId { get; set; }

}